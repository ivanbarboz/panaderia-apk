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
            string sql = "SELECT * FROM productos p INNER JOIN productos_categorias pc ON p.id = pc.id_producto WHERE pc.id_categoria = " + id;

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
    }
}
