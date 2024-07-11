namespace Entidades
{
    public class Serie
    {
        private string genero;
        private string nombre;

        public string Genero { get; set; }
        public string Nombre { get; set; }

        public string Alumno { get; set; }

        public Serie() { }

        public Serie(string nombre, string genero)
        {
            Nombre = nombre;
            Genero = genero;
        }

        public override string ToString()
        {
            return $"{Nombre} ({Genero})";
        }
    }
}
