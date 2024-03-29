﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Validations
{
    public class BirthDayAttribute : ValidationAttribute
    {
        public int MinimumAge { get; }
        public int MaximumAge { get; }

        public BirthDayAttribute(int minimumAge = 0, int maximumAge = 150)
        {
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
        }

        public override bool IsValid(object value)
        {
            if (!(value is DateTime date))
                return false; // it must be DateTime

            var age = DateTime.Today.Subtract(date).TotalDays / 365; // calc age
            return age > MinimumAge && age < MaximumAge;
        }
    }
}