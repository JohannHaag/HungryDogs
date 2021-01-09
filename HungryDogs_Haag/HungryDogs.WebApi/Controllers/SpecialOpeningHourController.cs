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
    public class SpecialOpeningHourController : ControllerBase
    {
        // GET: api/SpecialOpeningHour
        [HttpGet]
        public async Task<IEnumerable<ISpecialOpeningHour>> GetSpecialOpening()
        {
            using var ctrl = Logic.Factory.CreateSpecialOpeningHour();

            return await ctrl.GetAllAsync();
        }

        // GET: api/SpecialOpeningHour/1
        [HttpGet("{id}", Name = "GetSpecialOpeningHour")]
        public async Task<ISpecialOpeningHour> GetSpecialOpening(int id)
        {
            using var ctrl = Logic.Factory.CreateSpecialOpeningHour();

            return await ctrl.GetByIdAsync(id);
        }

        // POST: api/SpecialOpeningHour
        [HttpPost]
        public async Task PostSpecialOpening([FromBody] Logic.Entities.Persistence.SpecialOpeningHour item)
        {
            using var ctrl = Logic.Factory.CreateSpecialOpeningHour();

            await ctrl.InsertAsync(item);
            await ctrl.SaveChangesAsync();
        }


        // PUT: api/SpecialOpeningHour/1
        [HttpPut("{id}")]
        public async Task PutSpecialOpening(int id, [FromBody] Logic.Entities.Persistence.SpecialOpeningHour item)
        {
            using var ctrl = Logic.Factory.CreateSpecialOpeningHour();

            await ctrl.UpdateAsync(item);
            await ctrl.SaveChangesAsync();
        }


        // DELETE: api/SpecialOpeningHour/1
        [HttpDelete("{id}")]
        public async Task DeleteSpecialOpening(int id)
        {
            using var ctrl = Logic.Factory.CreateSpecialOpeningHour();

            await ctrl.DeleteAsync(id);
            await ctrl.SaveChangesAsync();
        }

    }
}
