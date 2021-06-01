using DataLibrary.Models;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IWatchData
    {
        /// <summary>
        /// [C]RUD - Insert a new watched bird with location etc.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<int> CreateWatch(WatchModel watch);

        /// <summary>
        /// C[R]UD - Query for bird watched
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>        /// 
        Task<WatchModel> GetWatchById(int watchId);

        /// <summary>
        /// CR[U]D - Update a specif location for bird watched
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderName"></param>
        /// <returns></returns>
        Task<int> UpdateLocation(int watchId, string location);

        /// <summary>
        /// CRU[D] - Delete a watch
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<int> DeleteWatch(int watchId);
    }
}