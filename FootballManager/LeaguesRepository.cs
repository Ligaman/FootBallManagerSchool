using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data;

namespace FootballManager;

public class LeaguesRepository
{
    public DataTable GetAllLeagues()
    {
        return Db.GetDataTable(
            "SELECT LeagueId, Name, Season FROM leagues ORDER BY Name, Season;");
    }

    public void CreateLeague(string name, string season)
    {
        Db.ExecuteNonQuery(
            "INSERT INTO leagues (Name, Season) VALUES (@name, @season);",
            new SqliteParameter("@name", name),
            new SqliteParameter("@season", season)
        );
    }

    public void UpdateLeague(int leagueId, string name, string season)
    {
        Db.ExecuteNonQuery(
            "UPDATE leagues SET Name = @name, Season = @season WHERE LeagueId = @leagueId;",
            new SqliteParameter("@name", name),
            new SqliteParameter("@season", season),
            new SqliteParameter("@leagueId", leagueId)
        );
    }

    public void DeleteLeague(int leagueId)
    {
        Db.ExecuteNonQuery(
            "DELETE FROM leagues WHERE LeagueId = @leagueId;",
            new SqliteParameter("@leagueId", leagueId)
        );
    }
}
