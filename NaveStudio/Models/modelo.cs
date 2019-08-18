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

    public class HorarioPedido : BaseModel
    {


        public HorarioPedido()
        {
            Cadastro = new Cadastro();
        }

        public HorarioPedido(Produto produto, DateTime horaEntrada, DateTime horaSaida, int quantidadeHora, decimal precoTotal, Cadastro cadastro)
        {
            Produto = produto;
            this.horaEntrada = horaEntrada;
            this.horaSaida = horaSaida;
            QuantidadeHora = quantidadeHora;
            PrecoTotal = precoTotal;
            Cadastro = cadastro;
        }

        [Required]

        public Cadastro Cadastro { get; set; }

        [Required]
        public Produto Produto { get; private set; }

        [Required]
        public DateTime horaEntrada { get; private set; }

        [Required]
        public DateTime horaSaida { get; private set; }

        [Required]
        public int QuantidadeHora { get; private set; }

        [Required]
        public decimal PrecoTotal { get; private set; }
    }

    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

       [Required]
       public HorarioPedido HorarioPedido { get; internal set; }

        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string email { get; set; } = "";
        [Required]
        public string bandaNome { get; set; } = "";
        [Required]
        public string Celular { get; set; } = "";

        public int horarioPedidoReferencia { get; set; }
    }


}
