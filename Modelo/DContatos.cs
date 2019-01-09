using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Modelo
{
    public class DContatos
    {
        private int _ContactID;
        private string _ContactType;
        private string _ContactName;
        private string _TextoBuscar;
        private string _CompanyName;


        public int ContactID { get => _ContactID; set => _ContactID = value; }
        public string ContactType { get => _ContactType; set => _ContactType = value; }
        public string ContactName { get => _ContactName; set => _ContactName = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string CompanyName { get => _CompanyName; set => _CompanyName = value; }

        //Paramentros
        public DContatos(int ContactID, string ContactType, string ContactName, string TextoBuscar, string CompanyName)
        {
            this.ContactID = ContactID;
            this.ContactName = ContactName;
            this.ContactType = ContactType;
            this.TextoBuscar = TextoBuscar;
            this.CompanyName = CompanyName;
            
        }

        //Vazio
        public DContatos()
        {

        }

 
        //Inserir Dados
        public string Inserir(DContatos Contatos)
        {
            string resp = "";
            SqlConnection SqlConn = new SqlConnection();
            try
            {
                //Abrindo Instancia
                SqlConn.ConnectionString = Conexao.connString;
                SqlConn.Open();

                //Executando Procedimento do BD
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = "InserirContatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Passando varíável IDContatos
                SqlParameter ParIdContatos = new SqlParameter();
                ParIdContatos.ParameterName = "@ContactID";
                ParIdContatos.SqlDbType = SqlDbType.Int;
                ParIdContatos.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdContatos);

                //Passando varíável Nome
                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@ContactName";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Contatos.ContactName;
                SqlCmd.Parameters.Add(ParNome);

                //Passando varíável Tipo
                SqlParameter ParType = new SqlParameter();
                ParType.ParameterName = "@ContactType";
                ParType.SqlDbType = SqlDbType.VarChar;
                ParType.Size = 50;
                ParType.Value = Contatos.ContactType;
                SqlCmd.Parameters.Add(ParType);

                //Passando varíável CompanyName
                SqlParameter ParCompany = new SqlParameter();
                ParCompany.ParameterName = "@CompanyName";
                ParCompany.SqlDbType = SqlDbType.VarChar;
                ParCompany.Size = 50;
                ParCompany.Value = Contatos.CompanyName;
                SqlCmd.Parameters.Add(ParCompany);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
            }
            return resp;
        }

        //Editar Dados
        public string Editar(DContatos Contatos)
        {
            string resp = "";
            SqlConnection SqlConn = new SqlConnection();
            try
            {
                //Abrindo Instancia
                SqlConn.ConnectionString = Conexao.connString;
                SqlConn.Open();

                //Executando Procedimento do BD
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = "EditarContatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Passando varíável IDContatos
                SqlParameter ParIdContatos = new SqlParameter();
                ParIdContatos.ParameterName = "@ContactID";
                ParIdContatos.SqlDbType = SqlDbType.Int;
                ParIdContatos.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdContatos);

                //Passando varíável Nome
                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@ContactName";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Contatos.ContactName;
                SqlCmd.Parameters.Add(ParNome);

                //Passando varíável Tipo
                SqlParameter ParType = new SqlParameter();
                ParType.ParameterName = "@ContactType";
                ParType.SqlDbType = SqlDbType.VarChar;
                ParType.Size = 50;
                ParType.Value = Contatos.ContactType;
                SqlCmd.Parameters.Add(ParType);

                //Passando varíável CompanyName
                SqlParameter ParCompany = new SqlParameter();
                ParCompany.ParameterName = "@CompanyName";
                ParCompany.SqlDbType = SqlDbType.VarChar;
                ParCompany.Size = 50;
                ParCompany.Value = Contatos.CompanyName;
                SqlCmd.Parameters.Add(ParCompany);

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Editado";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
            }
            return resp;
        }

        //Excluir Dados
        public string Excluir(DContatos Contatos)
        {
            string resp = "";
            SqlConnection SqlConn = new SqlConnection();
            try
            {
                //Abrindo Instancia
                SqlConn.ConnectionString = Conexao.connString;
                SqlConn.Open();

                //Executando Procedimento do BD
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = "DeletarContatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Passando varíável IDContatos
                SqlParameter ParIdContatos = new SqlParameter();
                ParIdContatos.ParameterName = "@ContactID";
                ParIdContatos.SqlDbType = SqlDbType.Int;
                ParIdContatos.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdContatos);

                //Passando varíável Nome
                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@ContactName";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Contatos.ContactName;
                SqlCmd.Parameters.Add(ParNome);

                //Passando varíável Tipo
                SqlParameter ParType = new SqlParameter();
                ParType.ParameterName = "@ContactType";
                ParType.SqlDbType = SqlDbType.VarChar;
                ParType.Size = 50;
                ParType.Value = Contatos.ContactType;
                SqlCmd.Parameters.Add(ParType);

                //Passando varíável CompanyName
                SqlParameter ParCompany = new SqlParameter();
                ParCompany.ParameterName = "@CompanyName";
                ParCompany.SqlDbType = SqlDbType.VarChar;
                ParCompany.Size = 50;
                ParCompany.Value = Contatos.CompanyName;

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Excluido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
            }
            return resp;
        }


        //Mostrar Dados
         public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Contacts");
            SqlConnection SqlConn = new SqlConnection();
            try
            {

                //Abrindo Instancia
                SqlConn.ConnectionString = Conexao.connString;
                SqlConn.Open();

                //Executando Procedimento do BD
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = "MostrarContatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;  
        }

        //Buscar Nome Contatos
        public DataTable BuscarNome(DContatos Contatos)
        {
            DataTable DtResultado = new DataTable("Contacts");
            SqlConnection SqlConn = new SqlConnection();
            try
            {
                //Abrindo Instancia
                SqlConn.ConnectionString = Conexao.connString;
                SqlConn.Open();

                //Executando Procedimento do BD
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = "BuscarContatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Passando varíável Nome Busca
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Contatos.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }




    }
}


