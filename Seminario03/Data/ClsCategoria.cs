using Microsoft.Data.SqlClient;
using Seminario03.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Seminario03.Services;

namespace Seminario03.Data
{
    public class ClsCategoria
    {
        public static List<Categoria> GetCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();
            string sql = "SELECT * FROM categorias";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Categoria reg = new Categoria()
                            {
                                id = rd.GetInt32(0),
                                nombre = rd.GetString(1)
                            };

                            ListaCategorias.Add(reg);
                        }
                    }
                }
                con.Close();
                return ListaCategorias;
                //NotificationService.SendNotification("Categorias", "Se han cargado las categorias");
            }
        }
    
        public static Categoria InsertCategoria(Categoria categoria)
        {
            string sql = "INSERT INTO categorias (nombre) VALUES (@nombre)";
            
            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = categoria.nombre;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            return categoria;
        }

        public static Categoria UpdateCategoria(Categoria categoria)
        {
            string sql = "UPDATE categorias SET nombre = @nombre WHERE id = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = categoria.nombre;
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = categoria.id;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            return categoria;
        }

        public static void DeleteCategoria(int id)
        {
            string sql = "DELETE FROM categorias WHERE id = @id";

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
