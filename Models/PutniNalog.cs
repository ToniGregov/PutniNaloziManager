using PutniNaloziManager.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PutniNalozi.Models
{
    public class PutniNalog
    {
        /*Potrebno za prikaz*/
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RedniBrojNaloga { get; set; }
        /// <summary>
        /// Datum i vrijeme polaska
        /// </summary>
        [Required]
        public DateTime Polazak { get; set; }

        /// <summary>
        /// DAtum i vrijeme povratka
        /// </summary>
        [Required]
        public DateTime Povratak { get; set; }
        /// <summary>
        /// Tekstualni opis
        /// </summary>
        [Required]
        public string RazlogPutovanja { get; set; }

        /// <summary>
        /// Mjesto polaska
        /// </summary>
        [Required]
        public string Polaziste { get; set; }
        /// <summary>
        /// Mjesto dolaska
        /// </summary>
        [Required]
        public string Odrediste { get; set; }
        /// <summary>
        /// Vrsta prijevoza (osobni automobil, službeni automobil ili javni prijevoz)
        /// </summary>
        [Required]
        public string Prijevoz { get; set; }

        /*Kod unosa novog naloga su potrebni i slijedeći podaci*/
        [ForeignKey("Automobil")]
        public string AutomobilID { get; set; }
        /// <summary>
        /// Obavezno ako tip prijevoza nije javni prijevoz 
        /// </summary>
        public Automobil Automobil { get; set; }
        /// <summary>
        /// Tekstualni unos komentara za cijeli putni nalog
        /// </summary>
        public string Komentar { get; set; }
        /// <summary>
        /// Email nadređene osobe kojoj se putni nalog šalje na odobrenje.
        /// Obavezan unos.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailZaOdobrenje { get; set; }

        /* U slučaju da je za put korišten automobil (osobni ili službeni) */

        public decimal PocetnaKilometraza { get; set; }
        public decimal ZavrsnaKilometraza { get; set; }
        [NotMapped]
        public IEnumerable<Trosak> Troskovi { get; set; }
        public bool IsLocked { get; set; }

        //[ForeignKey("Putnici")]
        //public string PutniciID { get; set; }
        ///// <summary>
        ///// Tekstualni prikaz imena i prezimena putnika, odvojeno zarezom
        ///// </summary>
        //[Required]
        //public IEnumerable<Putnik> Putnici { get; set; }

        public IEnumerable<PutniNaloziPutnici> PutniNaloziPutnici { get; set; }
    }

}
