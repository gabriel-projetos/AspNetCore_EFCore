using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public interface IEFCoreRepositorio
    {
        //Add recebe um paramaetro T, e esse parametro T é uma classe
        //E o metodo ADD está totalmente relacionado ao tipo <T>
        //Metodos genericos
        //Podemos passar qualquer entidade(heroi, batalha) etc
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Heroi[]> GetAllHerois();
        Task<Heroi> GetHeroiById();
        Task<Heroi> GetHeroiByNome();
        Task<bool> SaveChangedAsync();
    }
}
