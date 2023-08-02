using Microsoft.AspNetCore.Mvc;
using Store.Models.Model;
using Store.Repository.Service;

namespace Store.Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacters _charactersRepository;

        public CharactersController(ICharacters charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GET_Characters()
        {
            var characters = await _charactersRepository.Characters_GETS();

            return characters != null
                ? Ok(characters)
                : NotFound(new { message = "No There Registers" });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GET_Character(int id)
        {
            var character = await _charactersRepository.Character_GET(id);

            return character != null
                ? Ok(character)
                : NotFound(new { message = "No There Register" });
        }

        [HttpPost]
        public async Task<ActionResult> POST_Character(Characters characters)
        {
            var character = await _charactersRepository.Character_POST(characters);

            return character != null
                ? Ok(new { message = "Registed With Succesful" })
                : NotFound(new { message = "Already Exist a Register" });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> PUT_Character(Characters characters, int id)
        {
            var character = await _charactersRepository.Character_PUT(characters, id);

            return character == true
                ? Ok(new { message = "Updated With Succesful" })
                : NotFound(new { message = "No There Register" });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DELETE_Character(int id)
        {
            var character = await _charactersRepository.Character_DELETE(id);

            return character == true
                ? Ok(new { message = "Deleted With Succesful" })
                : NotFound(new { message = "No There Register" });
        }
    }
}