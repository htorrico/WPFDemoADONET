using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datos
{
    public class DCategoria
    {
        string connectionString = "Data Source=HUGO\\SQLEXPRESS02;Initial Catalog=StoreDB;Integrated Security=True;TrustServerCertificate=True";
        
        public List<Category> listar()
        {
            List<Category> lista = new List<Category>();

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("USP_SelCategories", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Category
                            {
                                IdCategory = Convert.ToInt32(dr["CategoryId"]),
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString()
                            });
                        }
                    }
                }

            return lista;
        }

        public void Insertar(string name, string description)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_InsCategory", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar() { }

        public void Eliminar() { }
        
    }
}
