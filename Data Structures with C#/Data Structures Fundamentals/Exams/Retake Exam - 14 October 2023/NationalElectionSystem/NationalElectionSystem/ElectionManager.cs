using System;
using System.Collections.Generic;
using System.Linq;

namespace NationalElectionSystem
{
    public class ElectionManager : IElectionManager
    {
        private Dictionary<string, Candidate> candidates;
        private Dictionary<string, Voter> voters;
        private Dictionary<string, List<string>> candidateVotes;
        private Dictionary<string, Voter> votedVoters;

        public ElectionManager()
        {
            this.candidates = new Dictionary<string, Candidate>();
            this.voters = new Dictionary<string, Voter>();
            this.candidateVotes = new Dictionary<string, List<string>>();
            this.votedVoters = new Dictionary<string, Voter>();
        }

        public void AddCandidate(Candidate candidate)
        {
            this.candidates[candidate.Id] = candidate;
            this.candidateVotes[candidate.Id] = new List<string>();
        }

        public void AddVoter(Voter voter)
        {
            this.voters[voter.Id] = voter;
        }

        public bool Contains(Candidate candidate)
        {
            return this.candidates.ContainsKey(candidate.Id);
        }

        public bool Contains(Voter voter)
        {
            return this.voters.ContainsKey(voter.Id);
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return this.candidates.Values;
        }

        public IEnumerable<Voter> GetVoters()
        {
            return this.voters.Values;
        }

        public void Vote(string voterId, string candidateId)
        {
            if (!this.candidates.ContainsKey(candidateId))
            {
                throw new ArgumentException();
            }

            if (!this.voters.ContainsKey(voterId) || this.voters[voterId].Age < 18)
            {
                throw new ArgumentException();
            }

            if (this.votedVoters.ContainsKey(candidateId))
            {
                throw new ArgumentException();
            }

            this.candidateVotes[candidateId].Add(voterId);
            this.votedVoters.Add(voterId, this.voters[voterId]);
        }

        public int GetVotesForCandidate(string candidateId)
        {
            return this.candidateVotes[candidateId].Count;
        }

        public IEnumerable<Candidate> GetWinner()
        {
            if (this.votedVoters.Count == 0)
            {
                return null;
            }

            return this.candidates.Values
                .Where(c => candidateVotes[c.Id].Count == this.candidateVotes.Values.Max(v => v.Count));
        }

        public IEnumerable<Candidate> GetCandidatesByParty(string party)
        {
            return this.candidates.Values
                .Where(c => c.Party == party);
        }
    }
}