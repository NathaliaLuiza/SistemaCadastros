using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;



namespace CamadaNegocio
{
   public class NContatos
    {

        public static string Inserir(string nome, string tipo, string company)
        {
            DContatos Obj = new Modelo.DContatos();
            Obj.ContactName = nome;
            Obj.ContactType = tipo;
            Obj.CompanyName = company;
            return Obj.Inserir(Obj);
            
        }

        public static string Editar(string nome, string tipo, string company)
        {
            DContatos Obj = new Modelo.DContatos();
            Obj.ContactName = nome;
            Obj.ContactType = tipo;
            Obj.CompanyName = company;
            return Obj.Editar(Obj);

        }

        public static string Excluir(int idContatos)
        {
            DContatos Obj = new Modelo.DContatos();
            Obj.ContactID = idContatos;
            return Obj.Excluir(Obj);

        }

        public static DataTable Mostrar()
        {
            DContatos Obj = new Modelo.DContatos();          
            return new DContatos().Mostrar();           

        }

        public static DataTable BuscarNome(string textoBuscar)
        {
            DContatos Obj = new Modelo.DContatos();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNome(Obj);

        }


    }
}
