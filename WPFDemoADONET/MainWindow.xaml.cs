using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;

namespace WPFDemoADONET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //ENTORNO DESCONECTADO

                SqlConnection connection = new SqlConnection("Data Source=HUGO\\SQLEXPRESS01;Initial Catalog=Neptuno;" +
                "Integrated Security=True;TrustServerCertificate=True");

                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Empleados", connection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                //Se va almacenar la información en memoria
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                connection.Close();
                //Mostrar la información en el DataGrid
                //ya no estoy conectado!!!!!!
                dtEmpleados.ItemsSource = dataTable.DefaultView;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }



        }

        private void btnListar2_Click(object sender, RoutedEventArgs e)
        {

            //ENTORNO CONECTADOS!!!!

            SqlConnection connection = new SqlConnection("Data Source=HUGO\\SQLEXPRESS01;Initial Catalog=Neptuno;" +
               "Integrated Security=True;TrustServerCertificate=True");

            connection.Open();

            SqlCommand command = new SqlCommand("USP_ListarEmpleados", connection);
            command.CommandType = CommandType.StoredProcedure;

            //Siempre que necesitar usar el datareader tienes que tener una conexión abierta
            SqlDataReader reader = command.ExecuteReader();

            List<Empleado> empleados = new List<Empleado>();


            while (reader.Read()) // ← Avanza fila por fila
            {
                int id = reader.GetInt32(reader.GetOrdinal("IdEmpleado"));
                string nombre = reader["Nombre"].ToString();
                string apellidos = reader["Apellidos"].ToString();
                string cargo = reader["Cargo"].ToString();
                string ciudad = reader["Ciudad"].ToString();


                empleados.Add(
                    new Empleado
                    {
                        IdEmpleado = id,
                        Apellidos = apellidos,
                        Nombre = nombre,
                        Cargo = cargo,
                        Ciudad = ciudad,
                    });

            }

            connection.Close();

      
            dtEmpleados.ItemsSource = empleados;

            connection = null;
            empleados = null;


        }
    }
}