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
    public partial class Form2 : Form
    {
        public Jugador user;
        private Panel[,] panelSiguientePieza;
        private Panel[,] panelTablero;
        private Pieza next;
        private int alto = 0;
        private int largo = 0;

        public Form2()
        {
            InitializeComponent();
            CrearMatrizSiguientePieza();
            String username;
            String pass;
            Form1 vistaLogin = new Form1();
            vistaLogin.ShowDialog();
            username = vistaLogin.textBoxUsuario.Text;
            pass = vistaLogin.textBoxPassword.Text;
            user = new Jugador(username, pass);
        }

        public static int [] ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            TextBox textBox2 = new TextBox() { Left = 50, Top = 70, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textBox2);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            if(prompt.ShowDialog() == DialogResult.OK)
            {
                int alto = Int32.Parse(textBox.Text);
                int largo = Int32.Parse(textBox2.Text);
                int []dimensiones = new int[2];
                dimensiones[0] = alto;
                dimensiones[1] = largo;
                return dimensiones;
            }

            return null;
        }

        public static int ShowDialog3(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                int size = Int32.Parse(textBox.Text);
                return size;
            }

            return 0;
        }

        public static int ShowDialog2(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                int size = Int32.Parse(textBox.Text);
                return size;
            }

            return 0;
        }

        public void AgregarSiguientePieza(int seed)
        {
            next = Tablero.NextPiece(seed);
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    panelSiguientePieza[i, j].BackColor = Color.White;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                panelSiguientePieza[next.Posiciones[i][1],3 - next.Posiciones[i][0]].BackColor = Color.Black;
            }
        }

        public void CrearMatrizSiguientePieza()
        {
            const int tileSize = 20;
            var clr = Color.White;
            panelSiguientePieza = new Panel[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var panelAct = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(670 + tileSize * i, 25 + tileSize * j),
                        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                    };

                    Controls.Add(panelAct);
                    panelSiguientePieza[i, j] = panelAct;
                    panelAct.BackColor = clr;
                }
            }
        }
        
        public void CrearTablero(int cantidadPiezas, int semilla)
        {
            int[] dimensiones = ShowDialog("Largo, Alto", "Ventana largo, alto");
            const int tileSize = 20;
            var clr = Color.White;

            this.alto = dimensiones[0];
            this.largo = dimensiones[1];

            
            panelTablero = new Panel[this.largo, this.alto];

            // double for loop to handle all rows and columns
            for (var n = 0; n < this.alto; n++)
            {
                for (var m = 0; m < this.largo; m++)
                {
                    // create new Panel control which will be one 
                    // chess board tile
                    var newPanel = new Panel
                    {

                        Size = new Size(tileSize, tileSize),
                        Location = new Point(25 + tileSize * n, 25 + tileSize * m),
                        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                    };

                    // add to Form's Controls so that they show up
                    Controls.Add(newPanel);
                    
                    panelTablero[m,n] = newPanel;

                    newPanel.BackColor = clr;
                }
            }
            Tablero.CreateBoard(largo, alto, cantidadPiezas, semilla);
        }

        private void comenzarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CrearTablero(0,0);
            
        }
        
        private void AgregarPieza(int alto, int largo)
        {
            panelTablero[this.largo - alto - 1, largo].BackColor = Color.DarkGray;
        }

        private void comenzarJuegoPredefinidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cantidadPiezas = ShowDialog2("Cantidad de piezas", "Cantidad de Piezas");
            int seed = ShowDialog3("Semilla", "Semilla");
            this.CrearTablero(cantidadPiezas, seed);
            for (int i = 0; i < Tablero.Posiciones.Count; i++)
            {
                int x = Tablero.Posiciones[i][1];
                int y = Tablero.Posiciones[i][0];
                this.AgregarPieza(y, x);
            }

        }

        private void buttonPiezaNueva_Click(object sender, EventArgs e)
        {
            int semilla = (Int32.Parse(this.textBoxSemilla.Text)%13);
            AgregarSiguientePieza(semilla);

        }

        public void ActualizarTablero()
        {
            for (int i = 0; i < this.alto; i++)
            {
                for (int j = 0; j < this.largo; j++)
                {
                    panelTablero[j, i].BackColor = Color.White;
                }
            }
            AgregarPiezas();
        }

        public void AgregarPiezas()
        {
            
            for (int i = 0; i < Tablero.Posiciones.Count; i++)
            {
                int x = Tablero.Posiciones[i][1];
                int y = Tablero.Posiciones[i][0];
                this.AgregarPieza(y, x);
            }

        }

        private void buttonJugar_Click(object sender, EventArgs e)
        {
            int posicionHorizontal = (Int32.Parse(this.textBoxPosHoriz.Text) % largo);
            int semilla = (Int32.Parse(this.textBoxSemilla.Text) % 13);
            Pieza next = Tablero.NextPiece(semilla);
            Tablero.Play(next, posicionHorizontal);
            if (Tablero.JuegoValido())
            {
                AgregarPiezas();
                
            }
            else
            {
                int i = 0;
                while (Tablero.Posiciones[i][0] < Tablero.Height)
                {
                    this.AgregarPieza(Tablero.Posiciones[i][0], Tablero.Posiciones[i][1]);
                    i++;
                }

                String perdida = "Ha perdido. Su puntaje es:"+ this.user.Puntaje;
                MessageBox.Show(perdida);
            }

            
        }

        private void buttonEliminarFilas_Click(object sender, EventArgs e)
        {
            Tablero.CheckBoard();
            ActualizarTablero();
            user.Puntaje += 100;
        }

        private void buttonRotar_Click(object sender, EventArgs e)
        {
            int semilla = (Int32.Parse(this.textBoxSemilla.Text) % 13);
            Pieza next = new Pieza(semilla);
            Pieza rotada = next.Rotar();
            AgregarSiguientePieza(rotada.Id);
        }
    }



}
