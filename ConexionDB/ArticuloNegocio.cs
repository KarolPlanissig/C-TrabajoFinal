using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases; 

namespace ConexionDB
{
      public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector; 

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true; ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio ,C.Descripcion Tipo, M.Descripcion Marca from ARTICULOS A, CATEGORIAS C, MARCAS M  where C.Id = A.IdCategoria and M.Id = A.IdMarca";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader(); 

                while(lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.CodigoArt = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marca = new Relacion();
                    aux.Marca.Descripcion = (string)lector["Marca"]; 
                    aux.Categoria = (int)lector["IdCategoria"];
                    aux.Imagen = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.Tipo = new Relacion(); 
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    

                    lista.Add(aux); 
                }
                conexion.Close(); 
                return lista; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Nombre, Codigo, Descripcion, IdMarca, IdCategoria, Precio, ImagenUrl) values(@Nombre,@Codigo,@Descripcion,@IdMarca,@IdCategoria,@Precio,@ImagenUrl)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Codigo", nuevo.CodigoArt);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca);
                datos.setearParametro("IdCategoria", nuevo.Categoria);
                datos.setearParametro("Precio", nuevo.Precio);
                datos.setearParametro("@ImagenUrl", nuevo.Imagen);

                datos.ejecutarAccion(); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion(); 
            }
        }
        public void modificarArticulo(Articulo modificar)
        {

        } 
        
    }
}
