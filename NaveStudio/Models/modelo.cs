using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NaveStudio.Models
{
    public class modelo
    {
    }

    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Produto : BaseModel
    {
        public Produto()
        {

        }

        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public decimal Preco { get; private set; }

        public Produto(string codigo, string nome, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }



    }

    public class CadastroHorario : BaseModel
    {
        public CadastroHorario(string email, DateTime horaEntrada, DateTime horaSaida, Produto produto)
        {
            this.email = email;
            this.horaEntrada = horaEntrada;
            this.horaSaida = horaSaida;
            Produto = produto;
        }

        public string email { get; set; }
        public DateTime horaEntrada {get; set;}
        public DateTime horaSaida { get; set; }
        public Produto Produto { get; private set; }



    }
    


}
