using System.Data.Common;

namespace AguadeCactus.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}