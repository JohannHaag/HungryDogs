using HungryDogs.Contracts.Modules.Common;
using HungryDogs.Contracts.Persistence;
using System.Collections.Generic;

namespace HungryDogs.Logic.Entities.Persistence
{
    public class Restaurant : VersionEntity, HungryDogs.Contracts.Persistence.IRestaurant
    {
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string UniqueName { get; set; }
        public string Email { get; set; }
        public RestaurantState State { get; set; }
      
    }
}

