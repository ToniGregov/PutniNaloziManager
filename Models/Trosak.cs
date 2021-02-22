using Microsoft.EntityFrameworkCore;

namespace PutniNalozi.Models
{
    [Keyless]
    public class Trosak
    {
        public string Opis { get; set; }
        public decimal Iznos { get; set; }
    }
}
