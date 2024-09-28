using Seminario03.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Seminario03.Data
{
    public class ClsProducto
    {
        public static List<Producto> GetProductos()
        {
            List<Producto> ListaProductos = new List<Producto>();
            string sql = "SELECT * FROM productos";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Producto reg = new Producto()
                            {
                                id = rd.GetInt32(0),
                                nombre = rd.GetString(1),
                                precio = rd.GetDecimal(2),
                                stock = rd.GetInt32(3),
                                image = rd.GetString(4)
                            };

                            ListaProductos.Add(reg);
                        }
                    }
                }
                con.Close();
                return ListaProductos;
            }
        }


        public static List<Producto> GetProductosPorCategoria(int id)
        {
            List<Producto> ListaProductos = new List<Producto>();
            string sql = "SELECT * FROM productos p INNER JOIN productos_categorias pc ON p.id = pc.id_producto WHERE pc.id_categoria = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Producto reg = new Producto()
                            {
                                id = rd.GetInt32(0),
                                nombre = rd.GetString(1),
                                precio = rd.GetDecimal(2),
                                stock = rd.GetInt32(3),
                                image = rd.GetString(4)
                            };

                            ListaProductos.Add(reg);
                        }
                    }
                }
                con.Close();
                return ListaProductos;
            }
        }

        public static Producto InsertProducto(Producto producto)
        {
            string sql = "INSERT INTO productos (nombre, precio, stock, image) VALUES (@nombre, @precio, @stock, @image)";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = producto.nombre;
                    cmd.Parameters.Add("@precio", System.Data.SqlDbType.Decimal).Value = producto.precio;
                    cmd.Parameters.Add("@stock", System.Data.SqlDbType.Int).Value = producto.stock;
                    cmd.Parameters.Add("@image", System.Data.SqlDbType.VarChar).Value = producto.image;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            return producto;
        }

        public static Producto UpdateProducto(Producto producto)
        {
            string sql = "UPDATE productos SET nombre = @nombre, precio = @precio, stock = @stock, image = @image WHERE id = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = producto.nombre;
                    cmd.Parameters.Add("@precio", System.Data.SqlDbType.Decimal).Value = producto.precio;
                    cmd.Parameters.Add("@stock", System.Data.SqlDbType.Int).Value = producto.stock;
                    cmd.Parameters.Add("@image", System.Data.SqlDbType.VarChar).Value = producto.image;
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = producto.id;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            return producto;
        }

        public static void DeleteProducto(int id)
        {
            string sql = "DELETE FROM productos WHERE id = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
