using Microsoft.Data.SqlClient;
using Seminario03.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario03.Data
{
    public class ClsCategoria
    {
        public static List<Categoria> GetCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();
            string sql = "Select * from categorias";

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
            }
        }
    }
}
