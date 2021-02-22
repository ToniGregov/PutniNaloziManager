using Microsoft.AspNetCore.Mvc;
using PutniNalozi.Models;
using System.Collections.Generic;

namespace PutniNalozi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutniNaloziController : ControllerBase
    {
        private readonly IPutniNaloziDAL objnalozi;
        public PutniNaloziController(IPutniNaloziDAL putniNaloziDAL)
        {
            objnalozi = putniNaloziDAL;
        }

        [HttpGet]
        public IEnumerable<PutniNalog> Index()
        {
            return objnalozi.GetAllPutniNalozi();
        }
        [HttpGet]
        [Route("Automobili")]
        public IEnumerable<Automobil> GetAutomobili()
        {
            return objnalozi.GetAllAutomobili();
        }
        [HttpGet]
        [Route("Putnici")]
        public IEnumerable<Putnik> GetPutnici()
        {
            return objnalozi.GetAllPutnici();
        }

        [HttpPost]
        [Route("Insert")]
        public int Insert([FromBody] object json)
        {
            PutniNalog nalog = Newtonsoft.Json.JsonConvert.DeserializeObject<PutniNalog>(json.ToString());
            return objnalozi.AddPutniNalog(nalog);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public PutniNalog Details(int id)
        {
            return objnalozi.GetPutniNalogData(id);
        }
        [HttpGet]
        [Route("Automobili/Details/{id}")]
        public Automobil AutoDetails(string id)
        {
            return objnalozi.GetAutomobilData(id);
        }

        [HttpPut]
        [Route("Edit")]
        public int Edit([FromBody] PutniNalog nalog)
        {
            return objnalozi.UpdatePutniNalog(nalog);
        }
        [HttpPut]
        [Route("Edit/Automobil")]
        public int EditAutomobil([FromBody] Automobil auto)
        {
            return objnalozi.UpdateAutomobilData(auto);
        }

        [HttpDelete]
        [Route("api/PutniNalozi/Delete/{id}")]
        public int Delete(int id)
        {
            return objnalozi.DeletePutniNalog(id);
        }

        
    }
}
