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

                    // evita que baje de 0 pero solo es visual
                    if (enemy.Health < 0)
                        enemy.Health = 0;

                    Console.WriteLine(enemy.Name + " tiene " + enemy.Health + " de vida.");

                    blocking = false;
                }

                else if (choice == "2")
                {
                    Console.WriteLine("Te cubres.");
                    blocking = true;
                }

                else
                {
                    Console.WriteLine("Accion invalida.");
                    continue;
                }

                // agregado para que el enemigo no ataque si está muerto, con la vida negativa seguia pegando eternamente
                if (!enemy.IsAlive())
                {
                    break; // corta el turno del enemigo muerto
                }

                if (enemy.IsAlive())
                {
                    if (blocking)
                    {
                        Console.WriteLine("Bloqueaste el ataque del enemigo.");

                        blocking = false;
                    }
                    else
                    {
                        enemy.Attack(player);

                        // agregado para que no se ponga en negativo visualmente
                        if (player.Health < 0)
                            player.Health = 0;
                    }
                }
            }

            return player.IsAlive();
        }
    }
}