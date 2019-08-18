using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using NaveStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaveStudio
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(t => t.Id);


            modelBuilder.Entity<HorarioPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<HorarioPedido>().HasOne(t => t.Produto);
            modelBuilder.Entity<HorarioPedido>().HasOne(t => t.Cadastro).WithOne(c => c.HorarioPedido).HasForeignKey<Cadastro>(t => t.horarioPedidoReferencia);


            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.HorarioPedido);




        }

    }
}
