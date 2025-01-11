using Npgsql;

namespace DiarioOficial.Domain.Interface.DatabaseAccessor.Base
{
    public interface INpgsqlService
    {
        Task<NpgsqlDataReader> ExecuteCommandAndReaderAsync(string query);
    }
}
