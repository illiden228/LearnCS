using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerXY
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(10, 5);
            Renderer render = new Renderer();

            render.DrawPlayer(player1.X, player1.Y);
            Console.ReadKey();
        }

        
    }

    class Renderer
    { 
        public void DrawPlayer(int x, int y, char symbol = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player (int x, int y)
        {
            X = x;
            Y = y;
        }

    }

}
