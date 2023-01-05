using Api_Cosmos.Models;
using Api_Cosmos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Cosmos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IcarCosmosService  carContext;
        public CarController(IcarCosmosService _carContext)
        {
            this.carContext = _carContext;
        }
        [HttpGet]
        public async Task<IActionResult>get()
        {
            var sqlcosmosQuery = "SELECT * FROM c";
            var result = await carContext.Get(sqlcosmosQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult>Post(car newcar)
        {
            newcar.ID = Guid.NewGuid().ToString();
            var result=await carContext.Add(newcar);
            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult>put(car updatecar)
        {
            var result = await carContext.Update(updatecar);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(string id,string make)
        {
            await carContext.Delete(id, make);
            return Ok();    

        }
    }
}
