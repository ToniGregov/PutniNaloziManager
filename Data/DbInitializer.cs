using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PutniNalozi.Models;

namespace PutniNalozi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PutniNaloziDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.PutniNalozi.Any())
            {
                return;   // DB has been seeded
            }

            var putniNalozi = new PutniNalog[]
            {
                new PutniNalog
                {
                    RedniBrojNaloga = 0, 
                    Polazak = DateTime.Now,
                    Povratak = DateTime.Now.AddDays(7),
                    RazlogPutovanja = "Prodaja novog proizvoda",
                    //Putnici = new List<Putnik>()
                    //{
                    //    new Putnik() { ID = "01", Ime = "Pero", Prezime = "Perić" },
                    //    new Putnik() { ID = "02", Ime = "Marko", Prezime = "Markić" },
                    //    new Putnik() { ID = "03", Ime = "Darko", Prezime = "Darkić" },
                    //},
                    Polaziste = "Zagreb",
                    Odrediste = "Osijek",
                    Prijevoz = TipPrijevoza.OsobniAutomobil.ToString(),
                    Automobil = new Automobil()
                    {
                        ID = "2",
                        Marka = "Tesla",
                        Naziv = "Model S",
                        RegistracijskaOznaka = "RI1235GR",
                        Kilometraza = 15000
                    },
                    Komentar = "",
                    EmailZaOdobrenje = "gospodin@director.hr",
                    PocetnaKilometraza = 0,
                    ZavrsnaKilometraza = 0,
                    Troskovi = new Trosak[]
                    {
                        new Trosak { Opis= "Benzin", Iznos = 200.00M},
                        new Trosak { Opis = "Cestarina",Iznos = 300.00M },
                        new Trosak { Opis = "Ručak", Iznos = 200.00M }
                    }
                }
            };
            foreach (PutniNalog pn in putniNalozi)
            {
                context.PutniNalozi.Add(pn);
            }
            context.SaveChanges();

            var automobili = new Automobil[]
            {
            new Automobil{ID="1",Marka="VolksWagen", Naziv="Golf", RegistracijskaOznaka="RI1234GR", Kilometraza=0},
            new Automobil{ID="2",Marka="Tesla", Naziv="Model S", RegistracijskaOznaka="RI1235GR", Kilometraza=15000},
            new Automobil{ID="3",Marka="Audi", Naziv="A4", RegistracijskaOznaka="RI1236GR", Kilometraza=0}
            };
            foreach (Automobil a in automobili)
            {
                context.Automobili.Add(a);
            }
            context.SaveChanges();

            var putnici = new Putnik[]
            {
            new Putnik{ID="1",Ime="Pero", Prezime="Perić"},
            new Putnik{ID="2",Ime="Marko", Prezime="Markić"},
            new Putnik{ID="3",Ime="Darko", Prezime="Darkić"}
            };
            foreach (Putnik p in putnici)
            {
                context.Putnici.Add(p);
            }
            context.SaveChanges();
        }
    }
}
