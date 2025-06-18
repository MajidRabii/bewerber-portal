using Microsoft.AspNetCore.Mvc;
using BewerbungAPP.Helpers; 
using BewerbungAPP.Models.Enums;  

namespace BewerbungApp.Controllers
{
    [ApiController]
    [Route("api/enums")]
    public class EnumsController : ControllerBase
    {
        [HttpGet("deutsch")]
        public IActionResult GetSprachlevel()
        {
            var list = EnumHelper.ToKeyValueList<Deutsch>();
            return Ok(list);
        }
        [HttpGet("niveau")]
        public IActionResult GetNiveau()
        {
            var list = EnumHelper.ToKeyValueList<Niveau>();
            return Ok(list);
        }
        [HttpGet("englisch")]
        public IActionResult GetEnglisch()
        {
            var list = EnumHelper.ToKeyValueList<Englisch>();
            return Ok(list);
        }
        [HttpGet("zertifikate")]
        public IActionResult GetZertifikate()
        {
            var list = EnumHelper.ToKeyValueList<Zertifikate>();
            return Ok(list);
        }
        [HttpGet("persisch")] 
        public IActionResult GetPersisch()
        {
            var list = EnumHelper.ToKeyValueList<Persisch>();
            return Ok(list);
        }
        [HttpGet("fuehrerschein")]
        public IActionResult GetFuehrerschein()
        {
            var list = EnumHelper.ToKeyValueList<Fuehrerschein>();
            return Ok(list);
        }
        [HttpGet("einsatzwunsch")]
        public IActionResult GetEinsatzwunsch()
        {
            var list = EnumHelper.ToKeyValueList<Einsatzwunsch>();
            return Ok(list);
        }
    }
}
