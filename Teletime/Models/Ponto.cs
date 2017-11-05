using System;
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

        public string EntradaSaida
        {
            get;
            set;
        }

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
