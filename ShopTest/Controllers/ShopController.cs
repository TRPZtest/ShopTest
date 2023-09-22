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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetClientResponse))]
        public async Task<IActionResult> GetClientsByBirthdate([FromQuery]DateTime birthDate)
        {
            var clients = await _repository.GetCLientsByDirthDate(birthDate);

            var clientsDtoList = _mapper.Map<List<ClientDto>>(clients);

            var response = new GetClientResponse { Clients = clientsDtoList };
            
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetClientResponse))]
        public async Task<IActionResult> GetLastClients([FromQuery]int daysAgo)
        {
            var clients = await _repository.GetLastClients(daysAgo);

            var clientsDtoList = _mapper.Map<List<ClientDto>>(clients);

            var response = new GetClientResponse { Clients = clientsDtoList };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesByClientId([FromQuery]long clientId)
        {
            throw new NotImplementedException();
        }
    }
}
