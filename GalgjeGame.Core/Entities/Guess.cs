using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Entities
{
    public class Guess
    {
        [Required(ErrorMessage = "Please enter a value")]
        [RegularExpression("^[a-z]+$", ErrorMessage = "Only lowercase letters allowed")]
        public char Letter { get; set; }
    }
}
