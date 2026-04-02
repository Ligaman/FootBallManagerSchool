using Microsoft.Data.Sqlite;
using System.Data;
using System.Text;

namespace FootballManager;

public class PlayersRepository
{
    public DataTable GetAllClubs()
    {
        return Db.GetDataTable("SELECT ClubId, Name FROM clubs ORDER BY Name;");
    }

    public DataTable GetPlayers(int? clubId = null, string? position = null, string? nameLike = null)
    {
        var sql = new StringBuilder(@"
SELECT 
    p.PlayerId,
    p.ClubId,
    c.Name AS ClubName,
    p.FullName,
    p.BirthDate,
    p.Position,
    p.ShirtNumber,
    p.Status
FROM players p
JOIN clubs c ON c.ClubId = p.ClubId
WHERE 1=1");

        var parameters = new List<SqliteParameter>();

        if (clubId.HasValue)
        {
            sql.Append(" AND p.ClubId = @clubId");
            parameters.Add(new SqliteParameter("@clubId", clubId.Value));
        }

        if (!string.IsNullOrWhiteSpace(position) && position != "All")
        {
            sql.Append(" AND p.Position = @position");
            parameters.Add(new SqliteParameter("@position", position));
        }

        if (!string.IsNullOrWhiteSpace(nameLike))
        {
            sql.Append(" AND p.FullName LIKE @nameLike");
            parameters.Add(new SqliteParameter("@nameLike", $"%{nameLike}%"));
        }

        sql.Append(" ORDER BY c.Name, p.FullName;");

        return Db.GetDataTable(sql.ToString(), parameters.ToArray());
    }

    public void Add(int clubId, string fullName, DateTime birthDate, string position, int? shirtNumber, string status)
    {
        Db.ExecuteNonQuery(@"
INSERT INTO players (ClubId, FullName, BirthDate, Position, ShirtNumber, Status)
VALUES (@clubId, @fullName, @birthDate, @position, @shirtNumber, @status);",
            new SqliteParameter("@clubId", clubId),
            new SqliteParameter("@fullName", fullName),
            new SqliteParameter("@birthDate", birthDate.ToString("yyyy-MM-dd")),
            new SqliteParameter("@position", position),
            new SqliteParameter("@shirtNumber", (object?)shirtNumber ?? DBNull.Value),
            new SqliteParameter("@status", status)
        );
    }

    public void Update(int playerId, int clubId, string fullName, DateTime birthDate, string position, int? shirtNumber, string status)
    {
        Db.ExecuteNonQuery(@"
UPDATE players
SET ClubId = @clubId,
    FullName = @fullName,
    BirthDate = @birthDate,
    Position = @position,
    ShirtNumber = @shirtNumber,
    Status = @status
WHERE PlayerId = @playerId;",
            new SqliteParameter("@clubId", clubId),
            new SqliteParameter("@fullName", fullName),
            new SqliteParameter("@birthDate", birthDate.ToString("yyyy-MM-dd")),
            new SqliteParameter("@position", position),
            new SqliteParameter("@shirtNumber", (object?)shirtNumber ?? DBNull.Value),
            new SqliteParameter("@status", status),
            new SqliteParameter("@playerId", playerId)
        );
    }

    public void Delete(int playerId)
    {
        Db.ExecuteNonQuery(
            "DELETE FROM players WHERE PlayerId = @playerId;",
            new SqliteParameter("@playerId", playerId)
        );
    }
}