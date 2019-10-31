using System.Collections.Generic;
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
    public class ImovelController : ControllerBase
    {
        private readonly IMoradaRepository _repo;
        private readonly IMapper _mapper;
        public ImovelController(IMoradaRepository repo, IMapper mapper)
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
            var imovel = await _repo.GetUser(id);
            var imovelToReturn = _mapper.Map<UserForDetailedDto>(imovel);
            return Ok(imovelToReturn);
        }
    }
}