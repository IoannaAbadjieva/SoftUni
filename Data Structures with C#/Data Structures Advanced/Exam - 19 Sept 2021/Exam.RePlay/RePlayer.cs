using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer
    {
        private HashSet<Track> allTracks = new HashSet<Track>();
        private Dictionary<string, Dictionary<string, Track>> albums = new Dictionary<string, Dictionary<string, Track>>();
        private LinkedList<Track> tracksQueue = new LinkedList<Track>();
        private Dictionary<string, Track> listeningQueue = new Dictionary<string, Track>();

        public void AddTrack(Track track, string album)
        {
            if (this.allTracks.Contains(track))
            {
                throw new ArgumentException();
            }

            if (!this.albums.ContainsKey(album))
            {
                this.albums.Add(album, new Dictionary<string, Track>());
            }

            track.Album = album;
            this.allTracks.Add(track);
            this.albums[album].Add(track.Title, track);
        }

        public bool Contains(Track track)
        => this.allTracks.Contains(track);

        public int Count => this.allTracks.Count;

        public Track GetTrack(string title, string albumName)
        {
            if (!this.albums.ContainsKey(albumName) || !this.albums[albumName].ContainsKey(title))
            {
                throw new ArgumentException();
            }

            return this.albums[albumName][title];
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!this.albums.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            return this.albums[albumName].Values.OrderByDescending(t => t.Plays);
        }

        public void AddToQueue(string trackName, string albumName)
        {
            if (!this.albums.ContainsKey(albumName) || !this.albums[albumName].ContainsKey(trackName))
            {
                throw new ArgumentException();
            }

            var track = this.albums[albumName][trackName];
            this.listeningQueue[track.Id] = track;
            this.tracksQueue.AddLast(track);
        }

        public Track Play()
        {
            if (tracksQueue.Count == 0)
            {
                throw new ArgumentException();
            }

            var track = this.tracksQueue.First.Value;
            track.Plays++;
            this.tracksQueue.RemoveFirst();
            this.listeningQueue.Remove(track.Id);

            return track;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            if (!this.albums.ContainsKey(albumName) || !this.albums[albumName].ContainsKey(trackTitle))
            {
                throw new ArgumentException();
            }

            var track = this.albums[albumName][trackTitle];
            this.albums[albumName].Remove(trackTitle);
            this.allTracks.Remove(track);
            if (this.listeningQueue.ContainsKey(track.Id))
            {
                this.tracksQueue.Remove(track);
                this.listeningQueue.Remove(track.Id);
            }
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        => this.allTracks
            .Where(t => t.DurationInSeconds >= lowerBound && t.DurationInSeconds <= upperBound)
            .OrderBy(t => t.DurationInSeconds)
            .ThenByDescending(t => t.Plays);

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
       => this.allTracks
            .OrderBy(t => t.Album)
            .ThenByDescending(t => t.Plays)
            .ThenByDescending(t => t.DurationInSeconds);


        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            var filteredTracks = this.allTracks
                .Where(t => t.Artist == artistName);

            if (filteredTracks.Count() == 0)
            {
                throw new ArgumentException();
            }

            var result = new Dictionary<string, HashSet<Track>>();
            foreach (var track in filteredTracks)
            {
                if (!result.ContainsKey(track.Album))
                {
                    result.Add(track.Album, new HashSet<Track>());
                }

                result[track.Album].Add(track);
            }

            return result.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToList());
        }


    }

}
