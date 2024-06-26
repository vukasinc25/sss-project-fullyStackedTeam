﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_FullyStackedTeam.Model
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return new Language
            {
                Id = Id,
                Name = Name
            };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
