using HungryDogs.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryDogs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        // GET: api/Restaurant
        [HttpGet]
        public async Task<IEnumerable<IRestaurant>> Get()
        {
            using var ctrl = Logic.Factory.CreateRestaurant();

            return await ctrl.GetAllAsync();
        }

        // GET: api/Restaurant/1
        [HttpGet("{id}", Name = "Get")]
        public async Task<IRestaurant> Get(int id)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();

            return await ctrl.GetByIdAsync(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task Post([FromBody] Logic.Entities.Persistence.Restaurant item)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();

            await ctrl.InsertAsync(item);
            await ctrl.SaveChangesAsync();
        }

        // PUT: api/Restaurant/1
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Logic.Entities.Persistence.Restaurant item)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();

            await ctrl.UpdateAsync(item);
            await ctrl.SaveChangesAsync();
        }

        // DELETE: api/Restaurant/1
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();

            await ctrl.DeleteAsync(id);
            await ctrl.SaveChangesAsync();
        }

      
        [HttpGet("{id}/close")]
        public async Task Close(int id)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();
            using var sctrl = Logic.Factory.CreateSpecialOpeningHour(ctrl);
            var specialOpeningHour = await sctrl.CreateAsync();
            specialOpeningHour.State = Contracts.Modules.Common.SpecialOpenState.Closed;
            await ctrl.GetByIdAsync(id);
            await ctrl.SaveChangesAsync();
        }
        [HttpGet("{id}/open")]
        public async Task Open(int id)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();
            using var sctrl = Logic.Factory.CreateSpecialOpeningHour(ctrl);
            var specialOpeningHour = await sctrl.CreateAsync();
            specialOpeningHour.State = Contracts.Modules.Common.SpecialOpenState.Open;
            await ctrl.GetByIdAsync(id);
            await ctrl.SaveChangesAsync();
        }
        [HttpGet("{id}/busy")]
        public async Task BusyClose(int id)
        {
            using var ctrl = Logic.Factory.CreateRestaurant();
            using var sctrl = Logic.Factory.CreateSpecialOpeningHour(ctrl);
            var specialOpeningHour = await sctrl.CreateAsync();
            specialOpeningHour.State = Contracts.Modules.Common.SpecialOpenState.IsBusy;
            await ctrl.GetByIdAsync(id);
            await ctrl.SaveChangesAsync();
        }
    }
}
