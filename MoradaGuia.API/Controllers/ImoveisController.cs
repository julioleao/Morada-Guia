using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoradaGuia.API.Data;
using MoradaGuia.API.Dtos;

namespace MoradaGuia.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly IMoradaRepository _repo;
        private readonly IMapper _mapper;
        public ImoveisController(IMoradaRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetImoveis()
        {
            var imoveis = await _repo.GetImoveis();
            var imoveisToReturn = _mapper.Map<IEnumerable<ImovelForListDto>>(imoveis);
            return Ok(imoveisToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImovel(int id)
        {
            var imovel = await _repo.GetImovel(id);
            var imovelToReturn = _mapper.Map<ImovelForDetailedDto>(imovel);
            return Ok(imovelToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImovel(int id, ImovelForUpdateDto imovelForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var imovelFromRepo = await _repo.GetImovel(id);

            _mapper.Map(imovelForUpdateDto, imovelFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new System.Exception($"Updating imovel {id} failed on save");
        }
    }
}