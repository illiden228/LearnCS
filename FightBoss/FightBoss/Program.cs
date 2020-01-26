using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightBoss
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            float maxPlayerHealth = 1000f;
            float maxEnemyHealth = 2000f;
            float playerHealth = 1000f;
            float enemyHealth = 2000f;
            string inputComand = "";
            int enemyComand;
            int call = 0;
            int coconStroke = 0;
            int bloodStroke = 0;

            Random rand = new Random();

            Console.Write("Введи свое имя, герой: ");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Добро пожаловать в бой с боссом, {name}!\nПеред тобой самый ужасный монстр из существующих - Огонек. У Огонька, как и у \nтебя, целых четыре способности!");
            Console.WriteLine("\nТебе нужно победить его своей силой!");
            Console.ReadKey();
            
            

            while (playerHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("\nКакую способность ты хочешь использовать?");
                Console.WriteLine("1. Кровавый призыв - ты открываешь портал, нанося себе урон в размере 100 HP, и в следующем ходу можешь призвать одного из существ");
                Console.WriteLine("2. Светлячки - существа, которые можно призвать только после кровавого призыва. Исцеляют тебе 150 HP или наносят противнику 100 урона");
                Console.WriteLine("3. Демон - существо, которое можно призвать только посе кровавого призыва. \nНаносит всем 200 урона");
                Console.WriteLine("4. Кокон - защитная оболочка, которая исцеляет 100 HP и защищает от следующего \nудара, при условии, что удар не огнем");
                Console.WriteLine("Ты можешь написать help, если хочешь узнать способности Огонька и clear, \nчтобы очистить окно");
                inputComand = Console.ReadLine();

                switch (inputComand)
                {
                    case "1":
                    case "Кровавый призыв":
                    case "кровавый призыв":
                        playerHealth -= 100;
                        call = 1;
                        break;
                    case "2":
                    case "Светлячки":
                    case "светлячки":
                        if (call >= 0)
                        {
                            playerHealth += 150;
                            if (playerHealth > maxPlayerHealth)
                            {
                                playerHealth = maxPlayerHealth;
                            }
                            enemyHealth -= 100;
                        }
                        else {
                            Console.WriteLine("Сейчас ты не можешь использовать эту способность");
                            continue;
                        }
                        break;
                    case "3":
                    case "Демон":
                    case "демон":
                        if (call >= 0)
                        {
                            playerHealth -= 200;
                            enemyHealth -= 200;
                        }
                        else
                        {
                            Console.WriteLine("Сейчас ты не можешь использовать эту способность");
                            continue;
                        }
                        break;
                    case "4":
                    case "Кокон":
                    case "кокон":
                        playerHealth += 100;
                        if (playerHealth > maxPlayerHealth)
                        {
                            playerHealth = maxPlayerHealth;
                        }
                        coconStroke = 1;
                        break;
                    case "help":
                        Console.WriteLine("Способности Огонька:");
                        Console.WriteLine("1. Пожирание - Огонек ест свою плоть и в ярости наносит игроку 300 урона. Из \nраны течет кровь, что отнимает у Огонька по 50 HP в этот следующие 2 хода");
                        Console.WriteLine("2. Огненная кровь - может быть активирована при истечении крови. Поджигает \nпротивника, нанося ему 150 урона и восстанавливая себе 50 HP");
                        Console.WriteLine("3. Обычный удар - наносит игроку случайный урон от 50 до 100");
                        Console.WriteLine("4. Пелвок - наносит 200 урона кислотой");
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "100":
                        enemyHealth = 0;
                        break;
                    case "1000":
                        playerHealth += enemyHealth;
                        enemyHealth = playerHealth - enemyHealth;
                        playerHealth -= enemyHealth;

                        maxPlayerHealth += maxEnemyHealth;
                        maxEnemyHealth = maxPlayerHealth - maxEnemyHealth;
                        maxPlayerHealth -= maxEnemyHealth;
                        break;
                }

                enemyComand = rand.Next(1,5);

                switch (enemyComand)
                {
                    case 1:
                        if (coconStroke < 1)
                        {
                            playerHealth -= 300;
                        }
                        bloodStroke = 3;
                        break;
                    case 2:
                    case 3:
                        if (bloodStroke > 0)
                        {
                            playerHealth -= 150;
                            enemyHealth += 50;
                            if (enemyHealth > maxEnemyHealth)
                            {
                                enemyHealth = maxEnemyHealth;
                            }
                            break;
                        }
                        
                        if (coconStroke < 1)
                        {
                            playerHealth -= rand.Next(50, 101);
                        }
                        break;
                    case 4:
                        if (coconStroke < 1)
                        {
                            playerHealth -= 200;
                        }
                        break;

                }

                if (bloodStroke > 0)
                {
                    enemyHealth -= 50;
                }

                call--;
                coconStroke--;
                bloodStroke--;
                Console.WriteLine($"У тебя осталось {playerHealth} HP");
                Console.WriteLine($"У Огонька {enemyHealth} HP");
            }


            if (playerHealth > 0)
            {
                Console.WriteLine($"Поздравляю, {name}! Ты победил!");
            }
            else {
                Console.WriteLine($"\nТы пал, {name}... Огонек победил! Надеюсь в следующий раз у тебя получится одолеть злобного Огонька");
            }
            Console.ReadKey();
        }
    }
}
