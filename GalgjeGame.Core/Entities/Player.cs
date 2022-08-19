using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GalgjeGame.Core.Entities
{
    public class Player
    {
        public long PlayerId { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters allowed")]
        public string UserName { get; set; }
        [JsonIgnore]
        public List<Game>? Games { get; set; }
    }
}