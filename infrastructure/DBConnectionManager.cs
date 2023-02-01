using Npgsql;

namespace e05.infrastructure;
public sealed class DBConnection // We need to use a singleton pattern to ensure we only have one connection to the database
{
    private static string Host = "localhost";
    private static string User = "development";
    private static string DBname = "development";
    private static string Password = "development"; //FIXME: This is not secure, find a way to store this in a profile or something
    private static string Port = "5432";


    private static string connString =
           String.Format(
               "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
               Host,
               User,
               DBname,
               Port,
               Password);

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connString); // dotnet add package Npgsql --version 7.0.1
    }

    private DBConnection()
    {
    }

    private static readonly Lazy<DBConnection> manager = new Lazy<DBConnection>(() => new DBConnection()); //Lazy is supported by .NET 4.0 and above

    public static DBConnection Instance
    {
        get
        {
            return manager.Value;
        }
    }
}