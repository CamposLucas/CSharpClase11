using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParaTest;
using System.Data.SqlClient;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        private Conexion conexion;
        private SqlConnection conn;

        public UnitTest1() {
            conexion = new Conexion();
            conn = conexion.crearConexion();
        }

        [TestMethod]
        public void abrirLaConexion()
        {
            /*
            conexion = new Conexion();
            conn = conexion.crearConexion();
            */
        }
        [TestMethod]
        public void creamosLaTabla()
        {
            new ManejoTabla(conn).creadorTabla();
        }
        [TestMethod]
        public void insert1()
        {
            new ManejoTabla(conn).insertarRegistro(11);
        }
        [TestMethod]
        public void insert2()
        {
            new ManejoTabla(conn).insertarRegistro(15);
        }
        [TestMethod]
        public void verificador()
        {
            int total = new ManejoTabla(conn).obtenerTotal();
            Assert.AreEqual(total, 26);
        }
        [TestMethod]
        public void borramosLaTabla()
        {
            new ManejoTabla(conn).destructorTabla();
        }
        [TestMethod]
        public void cerrarConexion()
        {
            conexion.Dispose();
        }        
    }
}
