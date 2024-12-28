using DiarioOficial.Domain.Interface.DatabaseAccessor.Base;
using Npgsql;

namespace DiarioOficial.Infraestructure.DatabaseAccessor.Base
{
    internal class NpgsqlService : INpgsqlService
    { 
        private readonly NpgsqlConnection _officialDiaryDbConnection;

        public NpgsqlService(NpgsqlConnection officialDiaryDbConnection)
        {
            _officialDiaryDbConnection = officialDiaryDbConnection;
            OpenOfficialDiaryConnectionIfNotOpen();
        }

        public async Task<NpgsqlDataReader> ExecuteCommandAndReaderAsync(string query)
        {
            using var command = new NpgsqlCommand(query, _officialDiaryDbConnection);
            return await command.ExecuteReaderAsync();
        }

        private void OpenOfficialDiaryConnectionIfNotOpen()
        {
            if (_officialDiaryDbConnection.State != System.Data.ConnectionState.Open)
                _officialDiaryDbConnection.Open();
        }
    }
}
