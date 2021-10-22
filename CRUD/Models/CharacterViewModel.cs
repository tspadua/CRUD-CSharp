using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class CharacterViewModel
    {
        public Character Character { get; set; }

        public IEnumerable<Region> Regions { get; set; }
    }
}
