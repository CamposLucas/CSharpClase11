using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ParaTest
{
    public class ManejoTabla
    {
        private SqlConnection conexionSQL = null;

        public ManejoTabla(SqlConnection sqlCon) {
            this.conexionSQL = sqlCon;
        }
        public void creadorTabla()
        {
            try
            {
                SqlCommand comando = conexionSQL.CreateCommand();
                comando.CommandText = "CREATE TABLE [dbo].[test]([ID][varchar](36) NOT NULL,[Int] [int] NOT NULL)";
                int reg = comando.ExecuteNonQuery();
                Console.WriteLine("La tabla se creo exitosamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        public void destructorTabla ()
        {
            try
            {
                SqlCommand comando = conexionSQL.CreateCommand();
                comando.CommandText = "DROP TABLE dbo.test";
                int reg = comando.ExecuteNonQuery();
                Console.WriteLine("La tabla se elimino exitosamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo borrar la tabla");
            }
        }
        public void insertarRegistro (int cant)
        {
            SqlCommand comando = conexionSQL.CreateCommand();
            comando.CommandText = "insert test (ID, Int) values ('" + Guid.NewGuid() +"', " + cant + ")";
            int reg = comando.ExecuteNonQuery();
            Console.WriteLine("El registro se inserto correctamente");
        }
        public int obtenerTotal() {
            SqlCommand comando = conexionSQL.CreateCommand();
            comando.CommandText = "select sum(Int) from dbo.test";
            int ret = (int)comando.ExecuteScalar();
            Console.WriteLine("El registro se inserto correctamente");
            return ret;
        }
    }
}
