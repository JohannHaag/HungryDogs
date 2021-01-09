using HungryDogs.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryDogs.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OpeningHourController:ControllerBase
    {
        // GET: api/OpeningHour
        [HttpGet]
        public async Task<IEnumerable<IOpeningHour>> GetOpening()
        {
            using var ctrl = Logic.Factory.CreateOpeningHour();

            return await ctrl.GetAllAsync();
        }

        // GET: api/OpeningHour/1
        [HttpGet("{id}", Name = "GetOpeningHour")]
        public async Task<IOpeningHour> GetOpening(int id)
        {
            using var ctrl = Logic.Factory.CreateOpeningHour();

            return await ctrl.GetByIdAsync(id);
        }

        // POST: api/OpeningHour
        [HttpPost]
        public async Task PostOpening([FromBody] Logic.Entities.Persistence.OpeningHour item)
        {
            using var ctrl = Logic.Factory.CreateOpeningHour();

            await ctrl.InsertAsync(item);
            await ctrl.SaveChangesAsync();
        }

        // PUT: api/OpeningHour/1
        [HttpPut("{id}")]
        public async Task PutOpening(int id, [FromBody] Logic.Entities.Persistence.OpeningHour item)
        {
            using var ctrl = Logic.Factory.CreateOpeningHour();

            await ctrl.UpdateAsync(item);
            await ctrl.SaveChangesAsync();
        }


        // DELETE: api/OpeningHour/1
        [HttpDelete("{id}")]
        public async Task DeleteOpening(int id)
        {
            using var ctrl = Logic.Factory.CreateOpeningHour();

            await ctrl.DeleteAsync(id);
            await ctrl.SaveChangesAsync();
        }

    }
}
