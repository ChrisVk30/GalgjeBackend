using System.ComponentModel.DataAnnotations;

namespace GalgjeGame.Core.Entities
{
    public class Word
    {
        [Required(ErrorMessage = "Please enter a value")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only letters allowed")]
        public string Value { get; set; }
    }
}