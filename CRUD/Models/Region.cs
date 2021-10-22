using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // One-To-Many //
        public virtual List<Character> Characters { get; set; }
    }
}
