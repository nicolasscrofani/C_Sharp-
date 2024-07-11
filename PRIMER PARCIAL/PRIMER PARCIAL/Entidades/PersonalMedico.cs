using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonalMedico : Persona
    {
        private List<Consulta> consultas = new List<Consulta>();
        private bool esResidente;


        public PersonalMedico(string nombre, string apellido, DateTime nacimiento, bool esResidente) : base(nombre, apellido, nacimiento)
        {
            this.esResidente = esResidente;
        }


        public static Consulta operator +(PersonalMedico doctor, Paciente paciente)
        {
            Consulta nuevaConsulta = new Consulta(DateTime.Now, paciente);
            doctor.consultas.Add(nuevaConsulta);
            return nuevaConsulta;
        }


        internal override string FichaExtra()
        {
            string ficha = $"¿Finalizó residencia? {(esResidente ? "SI" : "NO")}\nATENCIONES:\n";
            foreach (Consulta consulta in consultas)
            {
                ficha += $"{consulta}\n";
            }
            return ficha;
        }
    }
}
