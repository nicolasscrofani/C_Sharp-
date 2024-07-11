using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    {
        private string diagnostico;


        public string Diagnostico { get => diagnostico; set => diagnostico = value; }


        public Paciente(string nombre, string apellido, DateTime nacimiento, string barrioResidencia) : base(nombre, apellido, nacimiento, barrioResidencia)
        {

        }


        internal override string FichaExtra()
        {
            return $"Reside en: {barrioResidencia}\n{Diagnostico}";
        }
    }
}
