using JujutsuKaisen.Models.Model;
using JujutsuKaisen.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace JujutsuKaisen.Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        private readonly IClan _clanRepository;
        public ClanController(IClan clan)
        {
            _clanRepository = clan;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Clan_Gets()
        {
            var res = await _clanRepository.Clan_GETS();
            return res != null
              ? Ok(res)
              : NotFound(new { message = "Not Exist Registers" });
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Clan_Get(int id)
        {
            var res = await _clanRepository.Clan_GET(id);
            return res != null
              ? Ok(res)
              : NotFound(new { message = "Not Exist Register" });
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Clan_Post(Clan clan)
        {
            var res = await _clanRepository.Clan_POST(clan);
            return res != null
               ? Ok(new { message = "Register Created Successfully" })
               : NotFound(new { message = "Already a Register" });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Clan_Put(Clan clan, int id)
        {
            var res = await _clanRepository.Clan_PUT(clan, id);
            return res == true
               ? Ok(new { message = "Register Updated Successfully" })
               : NotFound(new { message = "Error To Update" });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Clan_Delete(int id)
        {
            var res = await _clanRepository.Clan_DELETE(id);
            return res == true
                ? Ok(new { message = "Register Eliminated Successfully" })
                : NotFound(new { message = "Error To Eliminate" });
        }
    }
}
