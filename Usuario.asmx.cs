using Matematicas3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace Matematicas3
{
    /// <summary>
    /// Summary description for Usuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Usuario : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void setNuevoUsuario(int id, String nombre, String apellido, DateTime fecha, string email, int pais)
        {
            ClsUsuario usuario = new ClsUsuario();
            usuario.setUsuario(id, nombre, apellido, fecha, email, pais);
        }

        [WebMethod]
        public void setDeleteUsuario(int id)
        {
            ClsUsuario usuario = new ClsUsuario();
            usuario.setEliminar(id);
        }

        [WebMethod]
        public void setUpdateUsario(int id, String nombre, String apellido, DateTime fecha, string email, int pais)
        {
            ClsUsuario usuario = new ClsUsuario();
            usuario.setUpdate(id, nombre, apellido, fecha, email, pais);
        }

        [WebMethod]
        public DataSet setSelectUsuario()
        {
            ClsUsuario usuario = new ClsUsuario();
            return  usuario.getSelect();
        }
    }
}
