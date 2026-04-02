using Microsoft.Data.Sqlite;
using System.Data;

namespace FootballManager;

public static class Db
{
    public static string DbPath =>
        Path.Combine(AppContext.BaseDirectory, "football.db");

    public static string ConnectionString =>
        $"Data Source={DbPath}";

    public static SqliteConnection GetConnection()
        => new SqliteConnection(ConnectionString);

    public static int ExecuteNonQuery(string sql, params SqliteParameter[] parameters)
    {
        using var conn = GetConnection();
        conn.Open();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        if (parameters != null && parameters.Length > 0)
            cmd.Parameters.AddRange(parameters);

        return cmd.ExecuteNonQuery();
    }

    public static DataTable GetDataTable(string sql, params SqliteParameter[] parameters)
    {
        using var conn = GetConnection();
        conn.Open();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        if (parameters != null && parameters.Length > 0)
            cmd.Parameters.AddRange(parameters);

        using var reader = cmd.ExecuteReader();
        var dt = new DataTable();
        dt.Load(reader);
        return dt;
    }

    public static void ExecuteTransaction(Action<SqliteConnection, SqliteTransaction> action)
    {
        using var conn = GetConnection();
        conn.Open();

        using var transaction = conn.BeginTransaction();
        try
        {
            action(conn, transaction);
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}

