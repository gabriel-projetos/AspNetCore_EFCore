using EFCore.Dominio;
using EFCore.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public class HeroiContext : DbContext
    {
        //public HeroiContext(){}
        //Base: chama o construtor pai, no caso do DbContext
        //o parametro optionsBuilder recebido aqui é criado no StartUp
        public HeroiContext(DbContextOptions<HeroiContext> optionsBuilder) : base(optionsBuilder)
        {}

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroiBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Para manter a referencia da string de conexão auqi precisa instalar o efcore.sqlserver
        //    //optionsBuilder.UseSqlServer("Password=Gg34821450;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=LAPTOP-0E5LQAT5");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Dizendo para o EF que estamos usando n x n, que tem uma chave composta, que heroi e batalha sao a chave composta
            modelBuilder.Entity<HeroiBatalha>(entity => 
            {
                //Tem chave? a chave composta é composta de BatalhaId e HeroiId, mas poderia ser varias
                entity.HasKey(e => new { e.BatalhaId, e.HeroId });
            });
        }

    }
}
