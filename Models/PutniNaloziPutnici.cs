using PutniNalozi.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNaloziManager.Models
{
    public class PutniNaloziPutnici
    {
        [ForeignKey("PutniNalog")]
        public int PutniNalogId { get; set; }
        public PutniNalog PutniNalog { get; set; }
        [ForeignKey("Putnik")]
        public string PutnikId { get; set; }
        public Putnik Putnik { get; set; }
    }
}
