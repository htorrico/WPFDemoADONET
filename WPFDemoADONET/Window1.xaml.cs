using Microsoft.Data.SqlClient;
using Models;
using Negocio;
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

namespace WPFDemoADONET
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
            try
            {
                NCategoria nCategoria = new NCategoria();
                nCategoria.ListarPorNombre("Carola");
                

                //dgCategories.ItemsSource = null;
                //dgCategories.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al listar: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
