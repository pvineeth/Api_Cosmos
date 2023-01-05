using Api_Cosmos.Models;
using Microsoft.Azure.Cosmos;

namespace Api_Cosmos.Services
{
    public class CarCosmosService :IcarCosmosService
    {
        private readonly Container container;
        public CarCosmosService(CosmosClient client,string databasename,string containerName )
        {
            container = client.GetContainer(databasename, containerName);

        }

        public async Task<car> Add(car newcar)
        {
            var iteam = await container.CreateItemAsync(newcar, new PartitionKey(newcar.Make));
            return iteam;
        }

        public Task Delete(string id, string make)
        {
            var iteam = container.DeleteItemAsync<car>(id, new PartitionKey(make));
            return iteam;
        }

        public async Task<List<car>> Get(string sqlCosmosQuery)
        {
            var query = container.GetItemQueryIterator<car>(new QueryDefinition(sqlCosmosQuery));
            List<car> result = new List<car>();
            while(query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response);
            }
            return result;
        }

        public async Task<car> Update(car updatecar)
        {
            var iteam = await container.UpsertItemAsync<car>(updatecar,new PartitionKey(updatecar.Make));
            return iteam;
        }
    }
}
