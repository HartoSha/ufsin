using Microsoft.AspNetCore.Mvc;
using UFSIN.Models;

namespace UFSIN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvictController : ControllerBase
    {
        private static readonly List<Convict> _convicts = new List<Convict>() { };
        public ConvictController() { }
        [HttpGet]
        public IEnumerable<Convict> GetAll()
        {
            return _convicts;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Convict bailiff)
        {
            _convicts.Add(bailiff);
            return Created("/bailiffs/", bailiff);
        }
    }
}
