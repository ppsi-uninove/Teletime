using System;
using System.Collections.Generic;

namespace Teletime.Models
{
    public class Cargo
    {
        public Cargo()
        {
            Funcionarios = new List<Funcionario>();
        }

        public int IDCargo
        {
            get;
            set;
        }

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
