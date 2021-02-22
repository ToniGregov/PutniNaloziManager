using PutniNaloziManager.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PutniNalozi.Models
{
    public class Putnik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        //[ForeignKey("Nalozi")]
        //public int NaloziID { get; set; }
        //public IEnumerable<PutniNalog> Nalozi { get; set; }
        public IEnumerable<PutniNaloziPutnici> PutniNaloziPutnici { get; set; }
    }
}
