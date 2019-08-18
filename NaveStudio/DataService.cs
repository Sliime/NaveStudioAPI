using Microsoft.EntityFrameworkCore;
using NaveStudio.Models;
using System.Linq;

namespace NaveStudio
{

    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public DataService(ApplicationContext context)
        {
            this.contexto = context;
        }

        public void InicializaDb()
        {
            contexto.Database.Migrate();

            var verificaLista = contexto.Set<Produto>().ToList();

           if (verificaLista.Count==0)
            {
                Produto p = new Produto("1", "Gravação", 100);
                Produto pe = new Produto("2", "Ensaio", 50);

                contexto.Set<Produto>().AddRange(p, pe);
                contexto.SaveChanges();
            }

        }

       
    }

}
