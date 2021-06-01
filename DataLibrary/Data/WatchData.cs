using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class WatchData : IWatchData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public WatchData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> CreateWatch(WatchModel watch)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Category", watch.Category);
            p.Add("BirdId", watch.BirdId);
            p.Add("Location", watch.Location);
            p.Add("Map", watch.Map);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spWatch_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public async Task<WatchModel> GetWatchById(int watchId)
        {
            var recs = await _dataAccess.LoadData<WatchModel, dynamic>("dbo.spWatch_GetById",
                new
                {
                    Id = watchId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }

        public Task<int> UpdateLocation(int watchId, string location)
        {
            return _dataAccess.SaveData("dbo.spWatch_UpdateLocation",
                                        new
                                        {
                                            Id = watchId,
                                            Location = location
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteWatch(int watchId)
        {
            return _dataAccess.SaveData("dbo.spWatch_Delete",
                                        new
                                        {
                                            Id = watchId
                                        },
                                        _connectionString.SqlConnectionName);
        }           
    
    }
}
