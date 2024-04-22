using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPI_EFCodeFirst.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_EFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerDataAccess dal;
        public CustomersController(ICustomerDataAccess dal)
        {
            this.dal = dal; 
        }

        // GET: api/<CustomersController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Customer> Get()
        {
            //int n1 = 100, n2 = 0;
            //int result = n1 / n2;

            return dal.GetAllCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return dal.GetCustomerById(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            dal.Add(customer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            dal.Update(customer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        [HttpPost]
        [Route("Authenticate/{username}/{password}")]
        public string Authenticate(string username,string password)
        {
            if(username=="Ramnath" && password=="admin123") //validate credentials from DAL layer
            {
                //generate the token 
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenKey = Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyzabcdefghij");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = "pratian",
                    Audience = "pratian",
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                throw new Exception("invalid user/password");
            }
        }
    }
}
