using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }

        //http://localhost:53635/api/Heroi
        // GET: api/<HeroiController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                //var herois = _context.Get
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroiController>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();
                return Ok("Incluido");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                //var heroi = new Heroi
                //{
                //    Id = id,
                //    Nome = "Gabriel",
                //    Armas = new List<Arma>
                //    {
                //        new Arma
                //        {
                //            Nome = "Cerebro"
                //        },
                //        new Arma
                //        {
                //            Nome = "Mark V"
                //        }
                //    }
                //};

                //Find trava a consulta
                //if(_context.Herois.Find(id) != null)

                //AsNoTracking nao trava
                if (_context.Herois.AsNoTracking().FirstOrDefault(heroi => heroi.Id == id) != null)
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();
                    return Ok("Atualizado");
                };
                return NotFound("Não encontrado.");

                
                //Tambem fucniona se tiramos o Update já que deixamos explicito que se trata da tabela Heroi no new Heroi
                //_context.Update(heroi);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
