using PutniNalozi.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PutniNalozi.Models
{
    public class Automobil
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string Marka { get; set; }
        public string Naziv { get; set; }
        [IsValidRegistracijskaOznaka]
        public string RegistracijskaOznaka { get; set; }
        public decimal Kilometraza { get; set; }
    }
}
