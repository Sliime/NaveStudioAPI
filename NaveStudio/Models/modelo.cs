﻿using System;
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


        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string NumeroCelular { get; set; }

        [Required]
        public DateTime HoraEntrada {get; set;}

        [Required]
        public DateTime HoraSaida { get; set; }
       



        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

    }
    


}
