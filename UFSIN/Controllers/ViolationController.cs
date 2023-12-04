using Microsoft.AspNetCore.Mvc;
using UFSIN.Models;

namespace UFSIN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViolationController : ControllerBase
    {
        private static readonly List<Violation> _violations = new List<Violation>() { };
        public ViolationController() { }

        [HttpGet]
        public IEnumerable<Violation> GetAll()
        {
            return _violations;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Violation violation)
        {
            _violations.Add(violation);
            return Created("/violation/", violation);
        }
    }
}
