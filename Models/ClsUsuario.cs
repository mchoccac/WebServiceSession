using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;

namespace Matematicas3.Models
{
    public class ClsUsuario
    {
        string constr = ConfigurationManager.ConnectionStrings["WebService_Conn"].ConnectionString;

        public ClsUsuario() {

        }
        public void setUsuario(int id, String nombre, String apellido, DateTime fecha, string email, int pais) {
            usuario user = new usuario();
            user.id = id;
            user.nombre = nombre;
            user.apellido = apellido;
            user.fecha_nacimiento = fecha;
            user.email = email;
            user.pais = pais;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_usuario"))
                {
                    try { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "insert");
                    cmd.Parameters.AddWithValue("@id", user.id);
                    cmd.Parameters.AddWithValue("@nombre", user.nombre);
                    cmd.Parameters.AddWithValue("@apellido", user.apellido);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", user.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@pais", user.pais);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    System.Web.HttpContext.Current.Response.Write("Ok");
                    }
                    catch (Exception ex) {
                        System.Web.HttpContext.Current.Response.Write(ex.Message);
                    }
                }
            }
        }
        public void setEliminar(int id) {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_usuario"))
                {
                    try
                    {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "delete");
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", "");
                    cmd.Parameters.AddWithValue("@apellido", "");
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", "");
                    cmd.Parameters.AddWithValue("@email", "");
                    cmd.Parameters.AddWithValue("@pais", "");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    System.Web.HttpContext.Current.Response.Write("Ok");
                    }
                    catch (Exception ex) {
                        System.Web.HttpContext.Current.Response.Write(ex.Message);
                    }
                }
            }
        }

        public void setUpdate(int id, String nombre, String apellido, DateTime fecha, string email, int pais) {
            usuario user = new usuario();
            user.id = id;
            user.nombre = nombre;
            user.apellido = apellido;
            user.fecha_nacimiento = fecha;
            user.email = email;
            user.pais = pais;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_usuario"))
                {
                    try
                    {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "update");
                    cmd.Parameters.AddWithValue("@id", user.id);
                    cmd.Parameters.AddWithValue("@nombre", user.nombre);
                    cmd.Parameters.AddWithValue("@apellido", user.apellido);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", user.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@pais", user.pais);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    System.Web.HttpContext.Current.Response.Write("Ok");
                }
                    catch (Exception ex)
                {
                    System.Web.HttpContext.Current.Response.Write(ex.Message);
                }
            }
            }
        }

        public DataSet getSelect() {

            DataSet dataTable = new DataSet();

            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["WebService_Conn"]
                .ConnectionString))
            {
                con.Open();


                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(
                    "SELECT * FROM usuario", con))
                {
                    sqlAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}