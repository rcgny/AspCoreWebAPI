using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class BirdData : IBirdData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public BirdData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<BirdModel>> GetBirds()
        {
            return _dataAccess.LoadData<BirdModel, dynamic>("dbo.spBirds_GetAll",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }
    }
}
