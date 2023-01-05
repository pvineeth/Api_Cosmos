using Api_Cosmos.Models;

namespace Api_Cosmos.Services
{
    public interface IcarCosmosService
    {
        Task<List<car>> Get(string sqlCosmosQuery);
        Task<car>Add(car newcar);
        Task<car>Update(car updatecar);
        Task Delete(string id, string make);
    }
}
