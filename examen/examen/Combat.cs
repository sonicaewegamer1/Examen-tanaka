using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    public class Combat : Situation
    {
        Enemy enemy;

        public Combat(string desc, Enemy enemy)
            : base(desc)
        {
            this.enemy = enemy;
        }


        public override bool Execute(Player player)
        {
            Console.WriteLine(Description);

            bool blocking = false; // es para bloquear ataques

            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine("");
                Console.WriteLine("¿Que haces?");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Cubrirse");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.Attack(enemy);
                    blocking = false;
                }

                else if (choice == "2")
                {
                    Console.WriteLine("Te cubres.");
                    blocking = true; // para cubrirse
                }

                else
                {
                    Console.WriteLine("Accion invalida.");
                    continue;
                }


                if (enemy.IsAlive())
                {
                    if (blocking)
                    {
                        Console.WriteLine(
                            "Bloqueaste el ataque del goblin."
                        );

                        blocking = false;
                    }

                    else
                    {
                        enemy.Attack(player);
                    }
                }
            }

            return player.IsAlive();
        }
    }
}