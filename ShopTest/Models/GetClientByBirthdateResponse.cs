using ShopTest.Data.Entities;
using System.Text.Json.Serialization;

namespace ShopTest.Models
{
    public class ClientDto
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
    }

    public class GetClientByBirthdateResponse
    {
        public IEnumerable<ClientDto> Clients { get; set; }
    }  
}
