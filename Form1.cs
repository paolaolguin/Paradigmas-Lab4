using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Clases;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void buttonLogin_Click(object sender, EventArgs e)
        {
            String usuario = this.textBoxUsuario.Text;
            String password = this.textBoxPassword.Text;
            Jugador user = new Jugador(usuario, password);
            MessageBox.Show("Bienvenido, " + user.Username);
            this.Close();
        }
    }
}
