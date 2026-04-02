using Microsoft.Data.Sqlite;
using System.Data;

namespace FootballManager;

public class ClubsRepository
{
    public DataTable GetAll()
    {
        return Db.GetDataTable("SELECT ClubId, Name, City FROM clubs ORDER BY Name;");
    }

    public void Add(string name, string? city)
    {
        Db.ExecuteNonQuery(
            "INSERT INTO clubs (Name, City) VALUES (@name, @city);",
            new SqliteParameter("@name", name),
            new SqliteParameter("@city", (object?)city ?? DBNull.Value)
        );
    }

    public void Update(int id, string name, string? city)
    {
        Db.ExecuteNonQuery(
            "UPDATE clubs SET Name=@name, City=@city WHERE ClubId=@id;",
            new SqliteParameter("@name", name),
            new SqliteParameter("@city", (object?)city ?? DBNull.Value),
            new SqliteParameter("@id", id)
        );
    }

    public void Delete(int id)
    {
        Db.ExecuteNonQuery(
            "DELETE FROM clubs WHERE ClubId=@id;",
            new SqliteParameter("@id", id)
        );
    }
}
