using System;
using System.Collections.Generic;

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

        public int IdDepartamento
        {
            get;
            set;
        }

        public int IdCargo
        {
            get;
            set;
        }

        public long? CPFResponsavel
        {
            get;
            set;
        }

        public DateTime DataAdmissao
        {
            get;
            set;
        }
   
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
