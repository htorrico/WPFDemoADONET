using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPFDemoADONET
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {

        string connectionString = "Data Source=HUGO\\SQLEXPRESS02;Initial Catalog=StoreDB;Integrated Security=True;TrustServerCertificate=True";
        public Categories()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("USP_InsCategory", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Categoría registrada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            try
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

                dgCategories.ItemsSource = null;
                dgCategories.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al listar: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
