using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Teletime.Models
{
    public class Cargo
    {
        public Cargo()
        {
            Funcionarios = new List<Funcionario>();
        }

        public int IdCargo
        {
            get;
            set;
        }

        [DisplayName("Cargo")]
        public string NomeCargo
        {
            get;
            set;
        }

        public ICollection<Funcionario> Funcionarios
        {
            get;
            set;
        }
    }
}
