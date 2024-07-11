using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Entidades;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSerializacionXML()
        {
            List<Serie> series = new List<Serie>
            {
                new Serie("Serie1", "Genero1"),
                new Serie("Serie2", "Genero2")
            };

            Serializadora serializadora = new Serializadora();
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Backlog.xml");

            serializadora.Guardar(series, ruta);

            Assert.IsTrue(File.Exists(ruta));
        }

        [TestMethod]


        public void TestSerializacionJSON()
        {
            List<Serie> series = new List<Serie>
            {
                new Serie("Serie1", "Genero1"),
                new Serie("Serie2", "Genero2")
            };

            IGuardar<List<Serie>> serializadora = new Serializadora();
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SeriesParaVer.json");

            serializadora.Guardar(series, ruta);

            Assert.IsTrue(File.Exists(ruta));
        }

        [TestMethod]
        [ExpectedException(typeof(BacklogException))]
        public void TestBacklogException()
        {
            throw new BacklogException("Test Exception");
        }
    }
}
