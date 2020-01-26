using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int maxLevels = 2;
            string lvlName = "";
            int level = 0;
            bool isPlaying = true;
            int playerX, playerY; 
            int playerDX = 0, playerDY = 0;
            int endX, endY;
            int[,] enemies = new int[0, 0];
            int[] enemyDirections;
            int maxDots, collectDots;
            int enemySpeed = 1500;
            bool alive = true;

            while (level < maxLevels && alive)
            {
                lvlName = "map" + (level + 1);
                isPlaying = true;
                maxDots = 0;
                collectDots = 0;

                char[,] map = ReadMap(lvlName, out playerY, out playerX, out endX, out endY, ref enemies, ref maxDots);
                DrawMap(map);
                enemyDirections = new int[enemies.GetLength(0)];
                for (int d = 0; d < enemyDirections.Length; d++)
                {
                    enemyDirections[d] = 1;
                }

                while (isPlaying)
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine($"Собрано {collectDots} / {maxDots}");
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        ChangeDirection(key, ref playerDX, ref playerDY);

                        if (map[playerX + playerDX, playerY + playerDY] != '#' && map[playerX + playerDX, playerY + playerDY] != '+')
                        {
                            Move(ref playerX, ref playerY, playerDX, playerDY);

                            CollectDots(map, playerX, playerY, ref collectDots);
                        }
                    }
                    if (enemySpeed == 0 )
                    {
                        EnemyMove(map, enemies, enemyDirections);
                        enemySpeed = 1500;
                    }
                    Win(map, enemies, collectDots, maxDots, endX, endY, playerX, playerY, ref isPlaying, ref alive);
                    enemySpeed--;
                }
                level++;
            }

            if (alive)
            {
                Console.Clear();
                Console.Write("Вы победили!");
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        static void Win(char[,] map, int[,] enemies, int collectDots, int maxDots, int endX, int endY, int x, int y, ref bool playing, ref bool alive)
        {
            for (int i = 0; i < enemies.GetLength(0); i++)
            {
                if (enemies[i, 0] == y && enemies[i, 1] == x)
                {
                    playing = false;
                    alive = false;
                    Console.Clear();
                    Console.WriteLine("Вас убили!");
                }
            }
            if (collectDots == maxDots)
            {
                Console.SetCursorPosition(endX, endY);
                Console.Write("=");
                map[endY, endX] = '=';
                if (map[x, y] == '=')
                {
                    playing = false;
                }
            }
        }

        static void CollectDots(char[,] map, int x, int y, ref int collectDots)
        {
            if (map[x, y] == '.')
            {
                collectDots++;
                map[x, y] = ' ';
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int dx, ref int dy)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    dx = -1; dy = 0;
                    break;
                case ConsoleKey.DownArrow:
                    dx = 1; dy = 0;
                    break;
                case ConsoleKey.RightArrow:
                    dx = 0; dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    dx = 0; dy = -1;
                    break;
            }
        }

        static void EnemyMove(char[,] map, int[,] enemies, int[] directions)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                x = enemies[i, 1];
                y = enemies[i, 0];
                if (map[x + directions[i], y] == '#')
                {
                    directions[i] *= -1;
                }
                Console.SetCursorPosition(y, x);
                if (map[x, y] == '$')
                {
                    map[x, y] = '.';
                }
                Console.Write(map[x, y]);
                enemies[i, 1] += directions[i];
                y = enemies[i, 0];
                x = enemies[i, 1];
                Console.SetCursorPosition(y, x);
                Console.Write('$');
            }
        }

        static void Move( ref int x, ref int y, int dx, int dy)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(' ');
            x += dx;
            y += dy;
            Console.SetCursorPosition(y, x);
            Console.Write('@');
        }

        static void DrawMap(char[,] map)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int x, out int y, out int endX, out int endY, ref int[,] enemies, ref int dots)
        {
            x = 0;
            y = 0;
            endX = 0;
            endY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] file = new char[newFile.Length,newFile[0].Length];
            for(int i = 0; i < file.GetLength(0); i++)
            {
                for (int j = 0; j < file.GetLength(1); j++)
                {

                    file[i, j] = newFile[i][j];
                    if (file[i, j] == '@')
                    {
                        x = j;
                        y = i;
                    }
                    else if (file[i, j] == '$')
                    {
                        AddEnemy(ref enemies, j, i);
                    }
                    else if (file[i, j] == ' ')
                    {
                        file[i, j] = '.';
                        dots++;
                    }
                    else if (file[i, j] == '=')
                    {
                        file[i, j] = '+';
                        endX = j;
                        endY = i;
                    }
                }
            }
            return file;
        }

        static void AddEnemy(ref int[,] oldMass, int newPositionX, int newPositionY)
        {
            int[,] newMass = new int[oldMass.GetLength(0) + 1, 2];
            int[] newPosition = { newPositionX, newPositionY };

            for (int i = 0; i < oldMass.GetLength(0); i++) 
            {
                for (int j = 0; j < 2; j++)
                {
                    newMass[i, j] = oldMass[i, j];
                }
            }
            for (int i = 0; i < 2; i++)
            {
                newMass[newMass.GetLength(0) - 1, i] = newPosition[i];
            }
            oldMass = newMass;
        }
    }
}
