using System;
using System.Collections.Generic;

namespace Teletime.Models
{
    public class Departamento
    {
        public Departamento()
        {
            Funcionarios = new List<Funcionario>();
        }

        public int IdDepartamento
        {
            get;
            set;
        }

        public string NomeDepartamento
        {
            get;
            set;
        }

        public virtual ICollection<Funcionario> Funcionarios
        {
            get;
            set;
        }
    }
}
