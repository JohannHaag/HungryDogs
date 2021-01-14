using HungryDogs.Contracts.Modules.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryDogs.Logic.Entities.Persistence
{
    public class SpecialOpeningHour : VersionEntity, HungryDogs.Contracts.Persistence.ISpecialOpeningHour
    {

        public int RestaurantId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Notes { get; set; }
        public SpecialOpenState State { get; set; }

        public SpecialOpeningHour()
        {
        }

        public SpecialOpeningHour(DateTime? @from, DateTime? to, string notes, SpecialOpenState state,int  resId)
        {
            From = @from;
            To = to;
            Notes = notes;
            State = state;
            RestaurantId = resId;
        }
    }
}
