using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Teletime.Models
{
    public class Funcionario
    {
        public Funcionario()
        {
            Pontos = new List<Ponto>();
            Subordinados = new List<Funcionario>();
        }

        public long CPF
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        [DisplayName("Id Departamento")]
        public int IdDepartamento
        {
            get;
            set;
        }

        [DisplayName("Id Cargo")]
        public int IdCargo
        {
            get;
            set;
        }


        [DisplayName("CPF Responsável")]
        public long? CPFResponsavel
        {
            get;
            set;
        }

        [DisplayName("Admissão")]
        public DateTime DataAdmissao
        {
            get;
            set;
        }
   
        [DisplayName("Demissão")]
        public DateTime? DataDemissao
        {
            get;
            set;
        }

        public Departamento Departamento
        {
            get;
            set;
        }

        public Cargo Cargo
        {
            get;
            set;
        }

        [DisplayName("Responsável")]
        public Funcionario Responsavel
        {
            get;
            set;
        }

        public virtual ICollection<Ponto> Pontos
        {
            get;
            set;
        }

        public virtual ICollection<Funcionario> Subordinados
        {
            get;
            set;
        }
    }
}
