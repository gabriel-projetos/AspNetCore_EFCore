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
    public class BatalhaController : ControllerBase
    {
        private readonly IEFCoreRepositorio _repo;

        public BatalhaController(IEFCoreRepositorio repo)
        {
            _repo = repo;
        }
        // GET: api/<BatalhaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois();

                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<BatalhaController>/5
        //
        [HttpGet("{id}", Name = "GetBatalha")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangedAsync())
                {
                    return Ok("Incluido");
                }
                return BadRequest("erro");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            //try
            //{
            //    if (_context.Batalhas.AsNoTracking().FirstOrDefault(heroi => heroi.Id == id) != null)
            //    {
            //        _context.Update(model);
            //        _context.SaveChanges();
                    return Ok("Atualizado");
            //    };
            //    return NotFound("Não encontrado.");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erro: {ex}");
            //}
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //try
            //{
            //    _repo.Delete(model);
            //    if (await _repo.SaveChangedAsync())
            //    {
            //        return Ok("Incluido");
            //    }
            //    return BadRequest("erro");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erro: {ex}");
            //}
        }
    }
}
