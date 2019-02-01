using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Clases
{
    public class Jugador
    {
        public String Username { get; private set; }
        public String Password { get; private set; }
        public int Puntaje { get; set; }
        private int[] PuntajesAltos { get; set; }
        private int PartidasJugadas;
        private int FilasEliminadas { get; set; }

        public Jugador(String user, String pass)
        {
            this.Username = user;
            this.Password = pass;
            this.Puntaje = 0;
        }
        
    }
}
