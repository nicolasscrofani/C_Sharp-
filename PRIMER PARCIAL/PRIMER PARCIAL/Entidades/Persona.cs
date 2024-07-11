using System;

namespace Entidades
{
    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        protected DateTime nacimiento;
        protected string barrioResidencia;


        public string NombreCompleto => $"{apellido}, {nombre}";
        public int Edad => DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

        public Persona(string nombre, string apellido, DateTime nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
        }

        public Persona(string nombre, string apellido, DateTime nacimiento, string barrioResidencia) : this(nombre, apellido, nacimiento)
        {
            this.barrioResidencia = barrioResidencia;
        }


        internal abstract string FichaExtra();

        public string FichaPersonal()
        {
            return $"{NombreCompleto}\nEDAD: {Edad}\n{FichaExtra()}";
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}