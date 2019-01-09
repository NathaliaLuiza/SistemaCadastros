using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Modelo
{
    class Conexao
    {
        
        //Windows Authentication
        public static string connString = @"server = .\sqlexpress;
                                            Database = northwind;
                                            integrated security = true;";

        // representa a conexão com o banco
        private static SqlConnection conn = null;

        // método que permite obter a conexão
        public static SqlConnection ObterConexao()
        {
            //conexão
            conn = new SqlConnection(connString);

            try
            {
                // abrir conexão e a devolve ao chamador do método
                conn.Open();
            }
            catch (SqlException sqle)
            {
                conn = null;
                
            }

            return conn;
        }
        //Fechar Conexão
        public static void FecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
