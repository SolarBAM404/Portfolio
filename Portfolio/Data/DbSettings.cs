class DbSettings
{
    public string ConnString { get; set; }
    public string DatabaseName { get; set; }

    public DbSettings(string connString, string databaseName)
    {
        ConnString = connString;
        DatabaseName = databaseName;
    }
}