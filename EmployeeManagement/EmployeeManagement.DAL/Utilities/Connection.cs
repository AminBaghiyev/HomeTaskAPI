using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.DAL.Utilities;

public class Connection
{
    public static string GetConnectionString(string key = "local", string json = "appsettings.json")
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "EmployeeManagement.API"));
        configurationManager.AddJsonFile(json);

        return
            configurationManager.GetConnectionString(key) ??
            throw new Exception("Connection string not found!");
    }
}
