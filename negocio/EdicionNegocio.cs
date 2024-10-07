using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EdicionNegocio
    {
        public List<Edicion> listar()
        {
            List<Edicion> lista = new List<Edicion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion From TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Edicion auxEd = new Edicion();
                    auxEd.Id = (int)datos.Lector["Id"];
                    auxEd.Descripcion = (string)datos.Lector["Descripcion"];
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
    }
}
