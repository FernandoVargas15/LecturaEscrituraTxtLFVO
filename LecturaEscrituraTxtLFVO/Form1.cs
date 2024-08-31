using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LecturaEscrituraTxtLFVO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string nombre = txbNombre.Text;
            string apellidos = txbApellidos.Text;
            string telefono = txbTelefono.Text;
            string estatura = txbEstatura.Text;
            string edad = txbEdad.Text;

            rdoHombre.Checked = false;
            rdoMujer.Checked = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //datos de los text box
            string nombres = txbNombre.Text;
            string apellidos = txbApellidos.Text;
            string edad = txbEdad.Text;
            string estatura = txbEstatura.Text;
            string Telefono = txbTelefono.Text;

            //genero
            string genero = "";
            if (rdoHombre.Checked)
            {
                genero = "Hombre";
            }
                else if (rdoMujer.Checked)
            {
                genero = "mujer";
            }

            //cadena de datos
            string datos = $"Nombres: {nombres}\r\nApellidos: {apellidos}\r\nTeléfono: {Telefono} \r\nEstatura: {estatura} cm\r\nEdad: {edad} años\r\nGenero: {genero}";

            //guardar datos en archivo de texto que existe
            string rutaArchivo = "C:/Users/fergu/OneDrive/Escritorio/GUARDAR_DATOS/datos.txt";

            bool archivoExiste = File.Exists(rutaArchivo);

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                if (archivoExiste)
                {
                    writer.WriteLine();
                }
            }

            //guardar datos en un archivo de texto cuando no existe
            bool archivoNoExiste = File.Exists(rutaArchivo);

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                if (archivoNoExiste)
                {
                    writer.WriteLine(datos);
                }
            }

            MessageBox.Show("Datos guardados con exito:\n\n" + datos, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //limpiar datos
            txbNombre.Clear();
            txbApellidos.Clear();
            txbEstatura.Clear();
            txbEdad.Clear();
            txbTelefono.Clear();
            rdoHombre.Checked = false;
            rdoMujer.Checked = false;

        }
    }
}
