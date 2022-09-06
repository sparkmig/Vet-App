using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Helpers;
using Vet.Models;

namespace Vet.Database
{
    public class DatabaseORM
    {
        private readonly SqlConnection _sqlConnection;

        public async Task<int> ExecStoredProcedure(string name)
        {
            SqlCommand command = new(name, _sqlConnection);
            return await command.ExecuteNonQueryAsync();
        }

        public DatabaseORM(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

    }
}
