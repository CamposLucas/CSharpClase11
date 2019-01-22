using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Transacciones
{
    public class Movimiento
    {
        private SqlConnection conn;
        public Movimiento(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void crearTablas() {

            var con = conn.CreateCommand();
            var SQLCmd = new StringBuilder()
                .Append("DROP TABLE dbo.CC; ")
                .Append("DROP TABLE dbo.CA; ")
                .Append("CREATE TABLE[dbo].[CC] ([Saldo] int NOT NULL); ")
                .Append("CREATE TABLE[dbo].[CA] ([Saldo] int NOT NULL); ")
                .Append("insert INTO CC(Saldo) values(1000); ")
                .Append("insert INTO CA(Saldo) values(1000); ")
                .ToString();

            con.CommandText = SQLCmd;
            con.ExecuteNonQuery();
    }
        public void Transac()
        {
            var sqlTransac = conn.BeginTransaction();
            
            try {
                var con = conn.CreateCommand();
                string SQLCmd = "UPDATE CC set Saldo-= 5;";
                con.CommandText = SQLCmd;
                con.Transaction = sqlTransac;
                con.ExecuteNonQuery();

                con = conn.CreateCommand();
                SQLCmd = "UPDATE CA set Saldo += 5;";
                con.CommandText = SQLCmd;
                con.Transaction = sqlTransac;
                con.ExecuteNonQuery();

                sqlTransac.Commit();
                Console.WriteLine("Todo ok !!!!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                sqlTransac.Rollback();
            }            
        }
    }    
}
