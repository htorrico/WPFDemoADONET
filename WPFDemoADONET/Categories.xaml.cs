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
using Models;
using Datos;
using Negocio;

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
                NCategoria nCategoria = new NCategoria();
                nCategoria.Insertar(txtName.Text, txtName.Text);

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
                DCategoria dCategoria = new DCategoria();
               

                dgCategories.ItemsSource = null;
                dgCategories.ItemsSource = dCategoria.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al listar: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
