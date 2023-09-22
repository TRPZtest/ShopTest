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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriesFrequenciesByClientId([FromQuery]long clientId)
        {
            var client = (await _repository.GetClientById(clientId)).FirstOrDefault();

            if (client == null)
                return NotFound();

            var products = await _repository.GetProductsByClientId(clientId);

            var categoriesFrequency = await _repository.GetCategoriesFrequencyByClientId(clientId);

            return Ok(new GetCategoriesFrequenciesResponse { CategoriesFrequencies = categoriesFrequency, Products = products });
        }
    }
}
