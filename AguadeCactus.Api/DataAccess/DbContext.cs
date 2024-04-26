using System.Data.Common;
using MySqlConnector;
using AguadeCactus.Api.DataAccess.Interfaces;

namespace AguadeCactus.Api.DataAccess;
public class DbContext : IDbContext
{
    private readonly IConfiguration _config;

    public DbContext(IConfiguration config)
    {
        _config = config;
    }
    private MySqlConnection _connection;
    public DbConnection Connection
    {
        get
        {
            if (_connection== null)
            {
                _connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
            return _connection;
        }
    }
}