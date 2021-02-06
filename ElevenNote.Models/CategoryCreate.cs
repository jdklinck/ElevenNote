using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
   public class CategoryCreate
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        
    }
}
