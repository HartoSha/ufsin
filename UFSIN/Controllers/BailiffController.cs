using Microsoft.AspNetCore.Mvc;
using UFSIN.Models;

namespace UFSIN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BailiffController : ControllerBase
    {
        private static readonly List<Bailiff> _bailiffs = new List<Bailiff>() {
            new Bailiff() {
                Convicts = new List<Convict>() { new Convict() { FullName = "Вася" } }
            } 
         };

        [HttpGet]
        public IEnumerable<Bailiff> GetAll()
        {
            return _bailiffs;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Bailiff bailiff)
        {
            _bailiffs.Add(bailiff);

            return Created("/bailiffs/", bailiff);
            //312313
            //31231
            //123123123
        }
    }
}
