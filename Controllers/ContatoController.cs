using BootcampDIO_Api.Context;
using BootcampDIO_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootcampDIO_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {

        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id}, contato);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contatos = _context.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            Contato contact =_context.Contatos.Find(id);
            if(contact == null)
                return NotFound();

            return Ok(contact);
        }

        
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contato = _context.Contatos.Where(x => x.Nome.Contains(nome));
            if(contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contato contact)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if(contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contact.Nome;
            contatoBanco.Telefone = contact.Telefone;
            contatoBanco.Ativo = contact.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);   
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contatos.Find(id);
            if(contact == null)
                return NotFound();

            _context.Contatos.Remove(contact);
            _context.SaveChanges();

            return NoContent();   

        }

    }
}