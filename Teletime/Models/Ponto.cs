using System;
using System.ComponentModel;

namespace Teletime.Models
{
    public class Ponto
    {
        public Ponto()
        {
        }

        public int IdPonto
        {
            get;
            set;
        }

        public long CPF
        {
            get;
            set;

        }

        [DisplayName("Entrada/Saída")]
        public string EntradaSaida
        {
            get;
            set;
        }

        [DisplayName("Data/Hora")]
        public DateTime DataHora
        {
            get;
            set;
        }


        public Funcionario Funcionario
        {
            get;
            set;
        }
    }
}
