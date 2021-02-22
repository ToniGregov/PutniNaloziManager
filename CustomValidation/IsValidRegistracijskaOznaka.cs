using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalozi.CustomValidation
{
    public class IsValidRegistracijskaOznaka : ValidationAttribute
    {
        /*
        *          Članak 18.
        * (2)  Registarski broj vozila sastoji se od tri ili četiri numeričke i jedne ili dvije slovne oznake.
        * (8)  Broj registarskih pločica za oldtimere (starodobna vozila) sastoji se od slovne oznake PV i tri ili četiri numeričke oznake.
        *          Članak 19.
        * (1)  Slovne oznake na registarskim pločicama upisuju se latiničnim pismom, a brojčane oznake arapskim brojkama. Oblik slova i 
        *      brojki tiskan je na Obrascu 15, a izgled grba na Obrascu 16.
        *          Članak 21.
        * (2)  Registarski broj iz stavka 1. ovoga članka ne može sadržavati slova Č, Ć, Đ, Š i Ž.
        *          Članak 22.
        * (1)  Vlasnik vozila može po izboru odabrati registarski broj koji se sastoji od najmanje tri do najviše sedam brojčanih 
        *      ili slovnih znakova ili od kombinacije brojčanih i slovnih znakova na dijelu registarske pločice iza oznake registracijskog 
        *      područja i grba Republike Hrvatske.
        * (2)  U slučaju izbora numeričkih znakova obvezno je odabrati najmanje jedan slovni znak. Između brojčanih i slovnih oznaka 
        *      obvezna je crtica, a između slovnih oznaka može se odabrati crtica. Crtica se računa kao jedan od znakova.
        * (3)  Registarski broj iz stavka 1. ovoga članka simetrično je otisnut te uključuje i strana slova X, Y i W.     
        * (8)  Iznimno od odredbe stavka 1. ovoga članka, u slučaju izbora samo slovnih znakova na obrascu 8 
        *      ili kombinaciji obrazaca 7 i 8, može se odabrati najmanje tri do najviše šest slovnih znakova.
        * (9)  Na registarskim pločicama iz članka. 24. ovog Pravilnika i oldtimera (starodobnih vozila) nije moguć 
        *      izbor znakova iz stavka 1. ovoga članka.     
        */
        string RegistracijskaOznaka { get; set; }
        private int BrNumOzn = 0;
        private int BrSloOzn = 0;
        public IsValidRegistracijskaOznaka()
        {
            if (RegistracijskaOznaka == null) RegistracijskaOznaka = "";
            BrNumOzn = BrojNumerickihOznaka();
            BrSloOzn = BrojSlovnihOznaka();
        }
        public bool IsValid()
        {
            if (BrNumOzn > 4 || BrSloOzn > 2)
            {
                if (BrNumOzn <= 7 && BrSloOzn >= 1) return true;
            }
            if (SadrziNelegalneOznake()) return false;

            return true;
        }

        private int BrojSlovnihOznaka()
        {
            return RegistracijskaOznaka.Count(char.IsLetter);
        }
        private int BrojNumerickihOznaka()
        {
            return RegistracijskaOznaka.Count(char.IsNumber);
        }
        private bool SadrziNelegalneOznake()
        {
            if (RegistracijskaOznaka.ToUpper().Contains('Č') ||
                RegistracijskaOznaka.ToUpper().Contains('Ć') ||
                RegistracijskaOznaka.ToUpper().Contains('Đ') ||
                RegistracijskaOznaka.ToUpper().Contains('Š') ||
                RegistracijskaOznaka.ToUpper().Contains('Ž'))
            {
                return false;
            }
            else return true;
        }
    }
}
