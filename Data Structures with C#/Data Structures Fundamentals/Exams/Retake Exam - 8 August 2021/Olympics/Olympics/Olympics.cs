using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{

    private Dictionary<int, Competition> competitionsById;
    private Dictionary<int, Competitor> participantsById;
    private Dictionary<int, List<int>> competitionParticipants;
    private Dictionary<int, List<int>> participantCompetitions;

    public Olympics()
    {
        competitionsById = new Dictionary<int, Competition>();
        participantsById = new Dictionary<int, Competitor>();
        competitionParticipants = new Dictionary<int, List<int>>();
        participantCompetitions = new Dictionary<int, List<int>>();
    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitionsById.ContainsKey(id))
        {
            throw new ArgumentException();

        }

        this.competitionsById[id] = new Competition(name, id, participantsLimit);
        this.competitionParticipants[id] = new List<int>();
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.participantsById.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.participantsById[id] = new Competitor(id, name);
        this.participantCompetitions[id] = new List<int>();
    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!this.competitionsById.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        if (!this.participantsById.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        if (this.participantCompetitions[competitorId].Contains(competitionId))
        {
            throw new ArgumentException();
        }

        this.participantCompetitions[competitorId].Add(competitionId);
        this.competitionParticipants[competitionId].Add(competitorId);
        this.participantsById[competitorId].TotalScore += this.competitionsById[competitionId].Score;
    }

    public int CompetitionsCount()
    {
        return this.competitionsById.Count;
    }

    public int CompetitorsCount()
    {
        return this.participantsById.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        return this.competitionParticipants[competitionId].Contains(comp.Id);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!this.competitionsById.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        if (!this.participantsById.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        if (!this.participantCompetitions[competitorId].Contains(competitionId))
        {
            throw new ArgumentException();
        }

        this.participantCompetitions.Remove(competitionId);
        this.participantsById[competitorId].TotalScore -= this.competitionsById[competitionId].Score;
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        return this.participantsById.Values
            .Where(p => p.TotalScore >= min && p.TotalScore <= max);
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        return this.participantsById.Values
             .Where(p => p.Name == name);
    }

    public Competition GetCompetition(int id)
    {
        if (!this.competitionsById.ContainsKey(id))
        {

            throw new ArgumentException();
        }

        return this.competitionsById[id];
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        return this.participantsById.Values
            .Where(p => p.Name.Length >= min && p.Name.Length <= max);
    }
}