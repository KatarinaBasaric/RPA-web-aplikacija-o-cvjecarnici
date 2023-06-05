using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cvjecarnica.Models
{
    public class Cvijet
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set;}

        [Required (ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Boja")]
       
        public string Boja { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Slika")]
        public string SlikaUrl { get; set; }

        [Display(Name = "Kategorija")]
        public int KategorijaId { get; set; }

        public Kategorija Kategorija { get; set; }


    }
}
