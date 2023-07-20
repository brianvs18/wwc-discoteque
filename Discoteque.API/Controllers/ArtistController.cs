using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;

namespace Discoteque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _artistService.GetArtistsAsync();
            return Ok(artists);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtistAsync(Artist artist){
            var entity = await _artistService.CreateArtistAsync(artist);
            return Ok(entity);
        }

        [HttpPost]
        [Route("CreateArtist")]
        public async Task<IActionResult> CreateArtist(Artist artist){
            var entity = await _artistService.CreateArtist(artist);
            return Ok(entity);
        }
    }
}