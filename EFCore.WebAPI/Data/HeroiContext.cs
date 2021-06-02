using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Colocar aqui a string de conexao para o banco de dados
            //Se a string nao tiver o Initial Catalog, deve ser adicionado. 
            //O nome do Catalog=HeroApp é o nome do Banco de Dados que desejamos criar
            optionsBuilder.UseSqlServer(@"Password=@cessoSQL1982;Persist Security Info=True;User ID=sa;Data Source=DESKTOP-IEK2ODL\SQLEXPRESS;Initial Catalog=HeroApp"); 
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId }); //Determina chave composta
            });
        }

    }
}
