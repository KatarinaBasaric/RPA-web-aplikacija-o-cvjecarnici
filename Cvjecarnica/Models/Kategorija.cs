using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cvjecarnica.Models
{
    public class Kategorija
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }

        public List<Cvijet> Cvijece { get; set; }

    }
}
