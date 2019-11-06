using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Api.Resources;
using MyMusic.Api.Validations;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

namespace MyMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        
        public ArtistsController(IArtistService artistService, IMapper mapper)
        {
            this._mapper = mapper;
            this._artistService = artistService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ArtistResource>>> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtists();
            var artistResources = _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistResource>>(artists);

            return Ok(artistResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistResource>> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistById(id);
            var artistResource = _mapper.Map<Artist, ArtistResource>(artist);

            return Ok(artistResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ArtistResource>> CreateArtist([FromBody] SaveArtistResource saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var artistToCreate = _mapper.Map<SaveArtistResource, Artist>(saveArtistResource);

            var newArtist = await _artistService.CreateArtist(artistToCreate);

            var artist = await _artistService.GetArtistById(newArtist.Id);

            var artistResource = _mapper.Map<Artist, ArtistResource>(artist);

            return Ok(artistResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistResource>> UpdateArtist(int id, [FromBody] SaveArtistResource saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var artistToBeUpdated = await _artistService.GetArtistById(id);

            if (artistToBeUpdated == null)
                return NotFound();

            var artist = _mapper.Map<SaveArtistResource, Artist>(saveArtistResource);

            await _artistService.UpdateArtist(artistToBeUpdated, artist);

            var updatedArtist = await _artistService.GetArtistById(id);

            var updatedArtistResource = _mapper.Map<Artist, ArtistResource>(updatedArtist);

            return Ok(updatedArtistResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetArtistById(id);

            await _artistService.DeleteArtist(artist);
            
            return NoContent();
        }
    }
}