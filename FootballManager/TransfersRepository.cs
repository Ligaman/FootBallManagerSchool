using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager;

public class TransfersRepository
{
    public DataTable GetPlayersWithCurrentClub()
    {
        return Db.GetDataTable(@"
SELECT p.PlayerId, p.FullName, p.ClubId, c.Name AS ClubName
FROM players p
JOIN clubs c ON c.ClubId = p.ClubId
ORDER BY p.FullName;");
    }

    public DataTable GetAllClubs()
    {
        return Db.GetDataTable("SELECT ClubId, Name FROM clubs ORDER BY Name;");
    }

    public DataTable GetTransfers(int? playerId = null)
    {
        var sql = new StringBuilder(@"
SELECT
    t.TransferId,
    t.TransferDate,
    p.FullName AS Player,
    fc.Name AS FromClub,
    tc.Name AS ToClub,
    t.Fee,
    t.Note
FROM transfers t
JOIN players p ON p.PlayerId = t.PlayerId
LEFT JOIN clubs fc ON fc.ClubId = t.FromClubId
JOIN clubs tc ON tc.ClubId = t.ToClubId
WHERE 1=1");

        var parameters = new List<SqliteParameter>();

        if (playerId.HasValue)
        {
            sql.Append(" AND t.PlayerId = @playerId");
            parameters.Add(new SqliteParameter("@playerId", playerId.Value));
        }

        sql.Append(" ORDER BY t.TransferDate DESC, t.TransferId DESC;");

        return Db.GetDataTable(sql.ToString(), parameters.ToArray());
    }

    public void AddTransfer(int playerId, int? fromClubId, int toClubId, DateTime transferDate, decimal? fee, string? note)
    {
        if (fromClubId.HasValue && fromClubId.Value == toClubId)
            throw new Exception("Играчът не може да бъде трансфериран в същия клуб.");

        Db.ExecuteTransaction((conn, transaction) =>
        {
            using var insertCmd = conn.CreateCommand();
            insertCmd.Transaction = transaction;
            insertCmd.CommandText = @"
INSERT INTO transfers (PlayerId, FromClubId, ToClubId, TransferDate, Fee, Note)
VALUES (@playerId, @fromClubId, @toClubId, @transferDate, @fee, @note);";

            insertCmd.Parameters.AddWithValue("@playerId", playerId);
            insertCmd.Parameters.AddWithValue("@fromClubId", (object?)fromClubId ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@toClubId", toClubId);
            insertCmd.Parameters.AddWithValue("@transferDate", transferDate.ToString("yyyy-MM-dd"));
            insertCmd.Parameters.AddWithValue("@fee", (object?)fee ?? DBNull.Value);
            insertCmd.Parameters.AddWithValue("@note", (object?)note ?? DBNull.Value);

            insertCmd.ExecuteNonQuery();

            using var updateCmd = conn.CreateCommand();
            updateCmd.Transaction = transaction;
            updateCmd.CommandText = @"
UPDATE players
SET ClubId = @newClubId
WHERE PlayerId = @playerId;";

            updateCmd.Parameters.AddWithValue("@newClubId", toClubId);
            updateCmd.Parameters.AddWithValue("@playerId", playerId);

            updateCmd.ExecuteNonQuery();
        });
    }
}
