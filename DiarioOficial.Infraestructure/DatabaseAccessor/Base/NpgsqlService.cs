using System.Data;
using DiarioOficial.Domain.Interface.DatabaseAccessor.Base;
using Npgsql;

namespace DiarioOficial.Infraestructure.DatabaseAccessor.Base
{
    internal class NpgsqlService : INpgsqlService
    {
        private readonly string _officialDiaryDbConnection;

        public NpgsqlService(string officialDiaryDbConnection)
        {
            _officialDiaryDbConnection = officialDiaryDbConnection;
        }

        public async Task<NpgsqlDataReader> ExecuteCommandAndReaderAsync(string query)
        {
            using var connection = new NpgsqlConnection(_officialDiaryDbConnection);
            await connection.OpenAsync();

            using var command = new NpgsqlCommand(query, connection);
            return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

    }
}
