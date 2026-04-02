using Microsoft.Data.Sqlite;

namespace FootballManager;

public static class DatabaseInit
{
    public static void Init()
    {
        EnsureDatabaseFileExists();
        RunScript("schema.sql");
        RunScript("seed.sql");
    }

    private static void EnsureDatabaseFileExists()
    {
        using var conn = Db.GetConnection();
        conn.Open();
    }

    private static void RunScript(string file)
    {
        var path = Path.Combine(AppContext.BaseDirectory, file);

        if (!File.Exists(path))
            throw new Exception($"SQL file not found: {path}");

        var sql = File.ReadAllText(path);

        using var conn = Db.GetConnection();
        conn.Open();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}