using Microsoft.EntityFrameworkCore;

using PutniNalozi.Data;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PutniNalozi.Models
{

    public interface IPutniNaloziDAL : IDisposable
    {
        IEnumerable<PutniNalog> GetAllPutniNalozi();
        IEnumerable<Automobil> GetAllAutomobili();
        IEnumerable<Putnik> GetAllPutnici();
        int AddPutniNalog(PutniNalog nalog);
        int UpdatePutniNalog(PutniNalog nalog);
        int UpdateAutomobilData(Automobil auto);
        PutniNalog GetPutniNalogData(int id);
        Automobil GetAutomobilData(string id);
        int DeletePutniNalog(int id);
    }

    public class PutniNaloziDAL : IPutniNaloziDAL
    {
        private readonly PutniNaloziDBContext db;
        public PutniNaloziDAL(PutniNaloziDBContext context)
        {
            db = context;
        }


        public IEnumerable<PutniNalog> GetAllPutniNalozi()
        {
            try
            {
                return db.PutniNalozi
                    .Include(a => a.Automobil)
                    //.Include(p => p.Putnici)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Automobil> GetAllAutomobili()
        {
            try
            {
                return db.Automobili.ToList();
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Putnik> GetAllPutnici()
        {
            try
            {
                return db.Putnici.ToList();
            }
            catch
            {
                throw;
            }
        }

        public PutniNalog GetPutniNalogData(int id)
        {
            try
            {
                PutniNalog nalog = db.PutniNalozi.Find(id);
                return nalog;
            }
            catch
            {
                throw;
            }
        }
        public Automobil GetAutomobilData(string id)
        {
            try
            {
                Automobil auto = db.Automobili.Find(id);
                return auto;
            }
            catch
            {
                throw;
            }
        }

        public int AddPutniNalog(PutniNalog nalog)
        {
            try
            {
                db.Automobili.Attach(nalog.Automobil);
                foreach(Putnik putnik in nalog.Putnici)
                {
                    db.Putnici.Attach(putnik);
                }
                
                db.PutniNalozi.Add(nalog);
                db.SaveChanges();
            }
            catch (Exception exe) {  }
            return 1;
        }

        
        public int UpdatePutniNalog(PutniNalog nalog)
        {
            try
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateAutomobilData(Automobil auto)
        {
            try
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }




        public int DeletePutniNalog(int id)
        {
            try
            {
                PutniNalog nalog = db.PutniNalozi.Find(id);
                db.PutniNalozi.Remove(nalog);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public void Dispose() { }
    }
}
