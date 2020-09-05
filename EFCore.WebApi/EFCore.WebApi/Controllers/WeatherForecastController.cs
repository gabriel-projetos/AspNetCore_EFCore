using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly HeroiContext _context;
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //Quando o construtor estiver esperando um contexto, ele pega o contexto que foi passado no startup        
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            HeroiContext heroiContext)
        {
            _logger = logger;
            _context = heroiContext;
            

        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            int mock = 0;
            _context.AddRange(
                new Heroi { Nome = $"Gabriel{mock++}"},
                new Heroi { Nome = $"Gabriel{mock++}" },
                new Heroi { Nome = $"Gabriel{mock++}" },
                new Heroi { Nome = $"Gabriel{mock++}" },
                new Heroi { Nome = $"Gabriel{mock++}" },
                new Heroi { Nome = $"Gabriel{mock++}" },
                new Heroi { Nome = $"Gabriel{mock++}" },
                new Heroi { Nome = $"Gabriel{mock++}" }
            );

            _context.SaveChanges();

            return Ok();
        }



        [HttpGet(), Route("[controller]/get/{nomeHero}")]
        public ActionResult Get(string nomeHero)
        {
            //Sem passar o id, ele considera um insert
            //Pssando id ele considera um update
            var heroi = new Heroi { Nome = nomeHero };

            var listHeroi = _context.Herois.
                Where(heroi => heroi.Nome.Contains(nomeHero)).
                FirstOrDefault();
                        

            //Dessa maneira eu explicitando quem recebe o Add
            _context.Herois.Add(heroi);
            //contexto.Add(heroi);

            _context.SaveChanges();            
            return Ok(heroi);
        }

        [HttpGet, Route("[controller]/Update/{nomeHero}")]
        public ActionResult Update(string nameHero)
        {
            var heroi = _context.Herois.
                Where(heroi => heroi.Id == 2).
                FirstOrDefault();

            heroi.Nome = "Iron Man";
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois.Where
                (x => x.Id == id)
                .Single();

            //Criando um estaço de deleção
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }


        [HttpGet("Listar")]
        public ActionResult Listar()
        {
            //Linq methods
            //var listHeroi = _context.Herois.ToList();

            //Dado heroi em Herois selecione para mim o heroi
            //do heroi contido em herois, pegue o heroi
            //Linq Querys
            var listHeroi = (from heroi in _context.Herois select heroi).ToList();
            return Ok(listHeroi);
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult GetHeroi(string nome)
        {
            //Linq methods
            //Toda vez que fazemos um ToList ele fecha a conexão
            //var listHeroi = _context.Herois.
            //Where(heroi => heroi.Nome.Contains(nome)).
            //ToList();

            //Usando like
            var listHeroi = _context.Herois.
                Where(heroi => EF.Functions.Like(heroi.Nome, $"%{nome}%"))
                .OrderBy(h => h.Id)
                .LastOrDefault();                
            //Para nao travar o banco nao podemos fazer um foreach percorendo o contexto, é melhor atribuir o contexto para uma variavel e entao percorrer a variavel igual abaixo
            //foreach (var item in listHeroi)
            //{

            //};


            //Dado heroi em Herois selecione para mim o heroi
            //do heroi contido em herois, pegue o heroi
            //Linq Querys
            //var listHeroi = (from heroi in _context.Herois 
            //                 where heroi.Nome.Contains(nome)
            //                 select heroi).ToList();
            return Ok(listHeroi);
        }



        [HttpGet]
        public IEnumerable<WeatherForecast> GetGeral()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
