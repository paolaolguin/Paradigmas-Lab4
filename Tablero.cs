using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Clases
{
    class Tablero
    {
        public static int Height { get; private set; }

        public static int Width { get; private set; }

        public static List<int[]> Posiciones { get; private set; }

        public static bool CheckSize(int height, int width)
        {
            if (height >= 10 && width >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Play(Pieza piece, int posHoriz)
        {
            piece.PiezaFueraDeTablero(Height, Width, posHoriz);
            BajarPieza(piece);
        }

        public static bool PosicionesValidas()
        {
            for (int i = 0; i < Posiciones.Count; i++)
            {
                if (Posiciones[i][1] >= Width)
                    return false;
            }
            return true;
        }

        public static void BajarPieza(Pieza piece)
        {
            for (int i = 0; i < 4; i++)
            {
                if (piece.Posiciones[i][0] == 0)
                {
                    AgregarPosiciones(piece);
                    return;
                }
            }
            for (int i = 0; i < Posiciones.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Posiciones[i][0] == piece.Posiciones[j][0] - 1 &&
               Posiciones[i][1] == piece.Posiciones[j][1])
                    {
                        AgregarPosiciones(piece);
                        return;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                piece.Posiciones[i][0]--;
            }
            BajarPieza(piece);
        }

        public static bool PosicionesSalidas()
        {
            for (int i = 0; i < Posiciones.Count; i++)
            {
                if (Posiciones[i][0] >= Height)
                    return true;
            }
            return false;
        }

        public static bool JuegoValido()
        {
            if (PosicionesSalidas())
                return false;
            return true;
        }


        public static void CreateBoard(int N, int M, int gamePieces, int seed)
        {
            if (CheckSize(N, M))
            {

                Console.WriteLine("Posiciones validas");
                Init(N, M);
                Pieza piece;
                int posHoriz;
                if (CheckBoard())
                {
                    Console.WriteLine("Agregando");
                    for (int i = 0; i < gamePieces; i++)
                    {
                        posHoriz = ((70*seed) + 3 + (seed*12) -7)% M;
                        piece = NextPiece(seed);
                        for (int j = 0; j < 4; j++)
                        {
                            if (piece.Posiciones[j][1] + posHoriz >= M)
                            {
                                posHoriz--;
                            }
                        }
                        Play(piece, posHoriz);
                        Console.WriteLine("Pieza agregada");
                        seed++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Tamano de Tablero no Valido. Comience el juego de nuevo.");

            }
        }

        public static void Init(int altura, int ancho)
        {
            if (CheckSize(altura, ancho))
            {
                Height = altura;
                Width = ancho;
                Posiciones = new List<int[]>(altura * ancho);
            }
            else
            {
                Console.WriteLine("Init: invalido");
            }
        }
        public static void AgregarPosiciones(Pieza piece)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                Posiciones.Add(piece.Posiciones[i]);
            }
        }

        public static List<int> CheckLines()
        {
            int i, j, contador;
            List<int> lineas = new List<int>(Height);
            for (i = 0; i < Height; i++)
            {
                contador = 0;
                for (j = 0; j < Posiciones.Count; j++)
                {
                    if (Posiciones[j][0] == i)
                    {
                        contador++;
                    }
                }
                if (contador == Width)
                {
                    lineas.Add(i);
                }
            }
            return lineas;
        }

        public static void EliminateLines(List<int> lineas)
        {
            int actual, indice = 0;
            int ancho = Width;
            while (lineas.Count != 0)
            {
                actual = lineas[0] - (indice++);
                for (int i = 0; i < Posiciones.Count; i++)
                {
                    if (Posiciones[i][0] == actual)
                    {
                        Posiciones.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < Posiciones.Count; i++)
                {
                    if (Posiciones[i][0] > actual)
                    {
                        Posiciones[i][0]--;
                    }
                }
                lineas.RemoveAt(0);
            }
        }

        public static int[,] CrearMatriz()
        {
            int j, k;
            int[,] matriz = new int[Height, Width];
            for (j = Height - 1; j > -1; j--)
            {
                for (k = Width - 1; k > -1; k--)
                {
                    matriz[j,k] = 0;
                }
            }
            return matriz;
        }

        public static Pieza NextPiece(int seed)
        {
            Pieza piece = new Pieza(seed);
            return piece;
        }

        public static String BoardToString()
        {
            String resultado = "";
            int i, j;
            int[,] matriz = CrearMatriz();
            for (i = 0; i < Posiciones.Count; i++)
            {
                for (j = 0; j < Height; j++)
                {
                    for (int k = 0; k < Width; k++)
                    {
                        if ((Posiciones[i][0] == j) && (Posiciones[i][1] == k))
                        {
                            matriz[j,k] = 1;

                        }
                    }
                }
            }
            for (i = Height - 1; i > -1; i--)
            {
                for (j = 0; j < Width; j++)
                {
                    resultado += matriz[i, j];
                }
                resultado += Environment.NewLine;
            }
            return resultado;
        }

        public static void PrintBoard()
        {
            String board = BoardToString();
            Console.WriteLine(board);
        }
        
        public static bool CheckBoard()
        {
            List<int> aEliminar = CheckLines();
            EliminateLines(aEliminar);

            if (CheckSize(Height, Width) && PosicionesValidas())
            {
                return true;
            }
            return false;

        }
    }
}
