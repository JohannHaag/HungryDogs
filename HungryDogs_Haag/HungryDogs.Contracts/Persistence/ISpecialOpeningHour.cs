﻿using HungryDogs.Contracts.Modules.Common;
using System;

namespace HungryDogs.Contracts.Persistence
{
    public interface ISpecialOpeningHour : IVersionable
    { 
        DateTime? From { get; set; }
        DateTime? To { get; set; }
        string Notes { get; set; }
        SpecialOpenState State { get; set; }
    }
}
