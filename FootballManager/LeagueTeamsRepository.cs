using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data;

namespace FootballManager;

public class LeagueTeamsRepository
{
    public DataTable GetParticipants(int leagueId)
    {
        return Db.GetDataTable(@"
SELECT c.ClubId, c.Name, c.City
FROM league_teams lt
JOIN clubs c ON c.ClubId = lt.ClubId
WHERE lt.LeagueId = @leagueId
ORDER BY c.Name;",
            new SqliteParameter("@leagueId", leagueId)
        );
    }

    public DataTable GetAvailableClubs(int leagueId)
    {
        return Db.GetDataTable(@"
SELECT c.ClubId, c.Name
FROM clubs c
LEFT JOIN league_teams lt 
    ON lt.ClubId = c.ClubId AND lt.LeagueId = @leagueId
WHERE lt.ClubId IS NULL
ORDER BY c.Name;",
            new SqliteParameter("@leagueId", leagueId)
        );
    }

    public void AddClubToLeague(int leagueId, int clubId)
    {
        Db.ExecuteNonQuery(
            "INSERT INTO league_teams (LeagueId, ClubId) VALUES (@leagueId, @clubId);",
            new SqliteParameter("@leagueId", leagueId),
            new SqliteParameter("@clubId", clubId)
        );
    }

    public void RemoveClubFromLeague(int leagueId, int clubId)
    {
        var dt = Db.GetDataTable(@"
SELECT COUNT(*) AS Cnt
FROM matches
WHERE LeagueId = @leagueId
  AND (HomeClubId = @clubId OR AwayClubId = @clubId);",
            new SqliteParameter("@leagueId", leagueId),
            new SqliteParameter("@clubId", clubId)
        );

        int count = Convert.ToInt32(dt.Rows[0]["Cnt"]);
        if (count > 0)
            throw new Exception("Не може да премахнеш клуба, защото вече има мачове в тази лига.");

        Db.ExecuteNonQuery(
            "DELETE FROM league_teams WHERE LeagueId = @leagueId AND ClubId = @clubId;",
            new SqliteParameter("@leagueId", leagueId),
            new SqliteParameter("@clubId", clubId)
        );
    }
}