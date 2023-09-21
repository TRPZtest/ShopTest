using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopTest.Data;
using ShopTest.Models;
using System.Text.Json;

namespace ShopTest.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _repository;
        private readonly IMapper _mapper;

        public ShopController(IMapper autoMapper, IShopRepository repository)
        { 
            _repository = repository;
            _mapper = autoMapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetClientByBirthdateResponse))]
        public async Task<IActionResult> GetClientByBirthdate([FromQuery]DateTime birthDate)
        {
            var clients = await _repository.GetCLientsByDirthDate(birthDate);

            var clientsDtoList = _mapper.Map<List<ClientDto>>(clients);

            var response = new GetClientByBirthdateResponse { Clients = clientsDtoList };
            
            return Ok(response);
        }
    }
}
