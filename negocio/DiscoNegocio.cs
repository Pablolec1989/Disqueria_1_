using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion Tipo From DISCOS D, ESTILOS E, TIPOSEDICION T where E.id=D.IdEstilo and T.id=D.IdTipoEdicion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanz = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)datos.Lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Descripcion = (string)datos.Lector["Tipo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdEdicion) values (@titulo, @fechalanz, @CantCanc, @img, @idEstilo, @idEdicion)");
                datos.setearParametro("@titulo", nuevo.Titulo);
                datos.setearParametro("@fechalanz", nuevo.FechaLanz);
                datos.setearParametro("@CantCanc", nuevo.CantCanciones);
                datos.setearParametro("@img", nuevo.UrlImagenTapa);
                datos.setearParametro("@idEstilo", nuevo.Edicion.Id);
                datos.setearParametro("@idEdicion", nuevo.Edicion.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
