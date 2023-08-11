using Clientes.Data;
using Clientes.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Clientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {

        private readonly ClientesAPIDbContext dbContext;

        public  ClientesController(ClientesAPIDbContext dbContext)
        {

            this.dbContext = dbContext;

        }

        [HttpGet]   
        public async Task <IActionResult> GetClientes()
        {
            return Ok( await dbContext.Clientes.ToListAsync());
         
        }


        [HttpPost]
        public async Task<IActionResult> AddCliente(AddClienteRequest addClienteRequest)
        {
            var cliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = addClienteRequest.Nome,
                Email = addClienteRequest.Email,
                Create_Client = DateTime.Now,
                Endereco = addClienteRequest.Endereco

            };

            await dbContext.Clientes.AddAsync(cliente);
            await dbContext.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCliente([FromRoute] Guid id, UpdateClienteRequest updateClienteRequest)
        {
            var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente != null)
            {
                cliente.Nome = updateClienteRequest.Nome;
                cliente.Email = updateClienteRequest.Email;
                cliente.DataAtualizacao = DateTime.Now;
                cliente.Endereco = updateClienteRequest.Endereco;

                await dbContext.SaveChangesAsync();


                return Ok();
              


            }
            return NotFound();
        }

            [HttpDelete]
            [Route("{id:guid}")]
            public async Task<IActionResult> DeleteCliente([FromRoute] Guid id)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);

            if(cliente != null)
            {
                dbContext.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return Ok(cliente); 

            }
       
             return NotFound();
        
        }
        }

}
