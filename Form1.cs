using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo3Colas
{
    public partial class ADMINISTRACIÓN : Form
    {
        Queue<Empleados> Trabajadores = new Queue<Empleados>(); //Creando un objeto de la clase cola, tipo empleado
        public ADMINISTRACIÓN()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();

            empleado.Carnet = txtCarnet.Text;
            empleado.Nombre = txtNombre.Text;
            empleado.Salario = decimal.Parse(txtSalario.Text);
            empleado.Fecha = Fecha.Value;

            Trabajadores.Enqueue(empleado);

            //Revisar lo de DGV COLA

            dgvCola.DataSource = null;
            dgvCola.DataSource = Trabajadores.ToArray();
            txtCarnet.Clear();
            txtNombre.Clear();
            txtSalario.Clear();
            txtCarnet.Focus();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Trabajadores.Count != 0) //mientras haya trabajadores en la cola
            {
                Empleados empleados = new Empleados();//inicializacion metodo empleado para ña recuperacion de datos

                empleados = Trabajadores.Dequeue();//metodo desencolar
                txtCarnet.Text = empleados.Carnet;
                txtNombre.Text = empleados.Nombre;
                txtSalario.Text = empleados.Salario.ToString();
                Fecha.Value = empleados.Fecha;
                dgvCola.DataSource = Trabajadores.ToList();
                MessageBox.Show("No hay empleados en cola", "AVISO");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No hay empleados en cola", "AVISO");
                Limpiar();
            }
            txtCarnet.Focus();
        }

        public void Limpiar()
        {
            txtCarnet.Clear();
            txtNombre.Clear();
            txtSalario.Clear();

        }
        
    
        
    }
}

    



