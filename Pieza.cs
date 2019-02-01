using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Clases
{
    class Pieza
    {
        public int Id {get; set; }

        public int[][] Posiciones { get; set; }

        public Pieza(int key)
        {
            this.Id = key % 13;
            this.Posiciones = new int[4][];
            for(int i = 0; i < 4; i++)
            {
                this.Posiciones[i] = new int[2];
            }
            switch (this.Id)
            {
                case 0:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 1;
                    this.Posiciones[3][1] = 1;
                    break;
                case 1:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 0;
                    this.Posiciones[2][1] = 2;
                    this.Posiciones[3][0] = 0;
                    this.Posiciones[3][1] = 3;
                    break;
                case 2:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 0;
                    this.Posiciones[2][0] = 2;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 3;
                    this.Posiciones[3][1] = 0;
                    break;
                case 3:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 0;
                    this.Posiciones[2][1] = 2;
                    this.Posiciones[3][0] = 1;
                    this.Posiciones[3][1] = 1;
                    break;
                case 4:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 1;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 1;
                    this.Posiciones[3][1] = 2;
                    break;
                case 5:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 0;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 1;
                    this.Posiciones[3][0] = 2;
                    this.Posiciones[3][1] = 0;
                    break;
                case 6:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 1;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 0;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 1;
                    this.Posiciones[3][0] = 2;
                    this.Posiciones[3][1] = 1;
                    break;
                case 7:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 1;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 2;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 2;
                    this.Posiciones[3][1] = 1;
                    break;
                case 8:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 2;
                    this.Posiciones[3][1] = 0;
                    break;
                case 9:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 1;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 2;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 2;
                    this.Posiciones[3][1] = 1;
                    break;
                case 10:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 0;
                    this.Posiciones[2][1] = 2;
                    this.Posiciones[3][0] = 1;
                    this.Posiciones[3][1] = 2;
                    break;
                case 11:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 1;
                    this.Posiciones[1][1] = 0;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 1;
                    this.Posiciones[3][0] = 2;
                    this.Posiciones[3][1] = 1;
                    break;
                case 12:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 1;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 2;
                    this.Posiciones[2][0] = 1;
                    this.Posiciones[2][1] = 0;
                    this.Posiciones[3][0] = 1;
                    this.Posiciones[3][1] = 1;
                    break;
                default:
                    this.Posiciones[0][0] = 0;
                    this.Posiciones[0][1] = 0;
                    this.Posiciones[1][0] = 0;
                    this.Posiciones[1][1] = 1;
                    this.Posiciones[2][0] = 0;
                    this.Posiciones[2][1] = 2;
                    this.Posiciones[3][0] = 0;
                    this.Posiciones[3][1] = 3;
                    break;
            }
        }

        public Pieza Rotar()
        {
            Pieza piece;
            if (this.Id == 0)
                return this;
            else if (this.Id == 1)
                piece = new Pieza(2);
            else if (this.Id == 2)
                piece = new Pieza(1);
            else if ((3 <= this.Id) && (this.Id < 6))
                piece = new Pieza(this.Id + 1);
            else if (this.Id == 6)
                piece = new Pieza(3);
            else if ((7 <= this.Id) && (this.Id < 10))
                piece = new Pieza(this.Id + 1);
            else if (this.Id == 10)
                piece = new Pieza(7);
            else if (this.Id == 11)
                piece = new Pieza(12);
            else
            {
                piece = new Pieza(11);
            }
            return piece;
        }

        public int Alto => this.Posiciones[3][0];

        public int Ancho
        {
            get
            {
                int anchoMax = this.Posiciones[0][1];
                for (int i = 0; i < 4; i++)
                {
                    if (anchoMax < this.Posiciones[i][1])
                    {
                        anchoMax = this.Posiciones[i][1];
                    }
                }

                return anchoMax;
            }
        }

        public bool CheckPiece(int altura, int ancho, int posHoriz)
        {
            if (this.Ancho + posHoriz < ancho)
            {
                return true;
            }
            return false;
        }

    void SumarAltura(int altura){
        for (int i = 0; i < 4; i++) {
            this.Posiciones[i][0] = this.Posiciones[i][0]+ altura;
        }
    }


    private void SumarHoriz(int horizontal){
        for (int i = 0; i < 4; i++) {
            this.Posiciones[i][1] = this.Posiciones[i][1]+ horizontal;
        }
    }

    private void PrintPiece(){
        for(int i = 0; i < 4; i++){
            Console.Write(this.Posiciones[i][0]+","+this.Posiciones[i][1]+"|");
        }
	Console.WriteLine("");
    }

    public void PiezaFueraDeTablero(int alturaT, int anchoT, int posHoriz){
        if (CheckPiece(alturaT, anchoT, posHoriz)){
            SumarAltura(alturaT);
            SumarHoriz(posHoriz);
        }
    }
    }
}
