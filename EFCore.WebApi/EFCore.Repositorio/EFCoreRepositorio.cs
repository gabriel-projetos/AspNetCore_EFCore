using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public class EFCoreRepositorio : IEFCoreRepositorio
    {
        private readonly HeroiContext _context;

        public EFCoreRepositorio(HeroiContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Heroi[]> GetAllHerois()
        {
            //Select com Join de heroi com Identidide Secreta e Armas
            //Relacionamento 1x1
            IQueryable<Heroi> query = _context.Herois
                .Include(heroi => heroi.IdentidadeSecreta)
                .Include(heroi => heroi.Armas);

            //relacionamento n x n
            query.Include(h => h.HeroisBatalhas)
                .ThenInclude(heroi => heroi.Batalha);

            query = query.AsNoTracking().OrderBy(heroi => heroi.Id);

            return await query.ToArrayAsync();
        }

        public Task<Heroi> GetHeroiById()
        {
            throw new NotImplementedException();
        }

        public Task<Heroi> GetHeroiByNome()
        {
            throw new NotImplementedException();
        }
    }
}
