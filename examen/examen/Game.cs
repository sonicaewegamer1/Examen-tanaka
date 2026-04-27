using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    public class Game
    {
        Player player;


        public void Start()
        {
            Console.WriteLine("Ingresa tu nombre:");
            string name = Console.ReadLine();

            player = new Player(name);

            QuestStart();
        }



        public void QuestStart()
        {
            Console.WriteLine("");
            Console.WriteLine("Escoge un camino:");
            Console.WriteLine("1. Bosque Oscuro");
            Console.WriteLine("2. Santuario");
            Console.WriteLine("3. Puerta de Piedra");

            string choice = Console.ReadLine();


            if(choice=="1")
            {
                GoblinPath();
            }

            else if(choice=="2")
            {
                TreasurePath();
            }

            else if(choice=="3")
            {
                TrapPath();
            }

            else
            {
                Console.WriteLine("Opcion invalida.");
                QuestStart();
            }

        }



        public void GoblinPath()
        {
            Console.WriteLine("");
            Console.WriteLine("¡Comienza el combate!"); // introducción al combate

            Combat fight =
                new Combat(
                    "Un goblin aparece.",
                    new Enemy("Goblin", 15, 3)
                );

            bool alive = fight.Execute(player);

            if (!alive)
            {
                Restart();
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Derrotaste al goblin.");
            Console.WriteLine("Llegas al mundo goblin.");//temporal
            Console.WriteLine("Final Bueno.");
        }



        public void TreasurePath()
        {
            Event potion =
                new Event(
                    "Encuentras una pocion.",
                    new HealthPotion()
                );

            potion.Execute(player);

            Console.WriteLine("");
            Console.WriteLine("El santuario se divide en dos caminos...");
            Console.WriteLine("1. Cámara del guerrero");
            Console.WriteLine("2. Pasillo oscuro");

            string choice = Console.ReadLine();

            // espada
            if (choice == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("Encuentras una espada antigua.");
                Console.WriteLine("Tu daño aumenta");

                player.Damage += 5; // daño aumentado
            }

            else if (choice == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("Sigues tu camino");
            }
            Console.WriteLine("");
            Console.WriteLine("Un Lycantropo aparece...");

            // AGREGAR COMBATE
            Combat fight =
                new Combat(
                    "este emerge de las sombras...",
                    new Enemy("Lycantropo", 45, 7)
                );

            bool alive = fight.Execute(player);

            if (!alive)
            {
                Restart();
                return;
            }
        }

        public void TrapPath()
        {
            Console.WriteLine("");
            Console.WriteLine("Caes por un precipicio.");
            Console.WriteLine("Final Malo.");

            Restart();
        }



        public void Restart()
        {
            Console.WriteLine("----un hada te ha resusitado----");
            Console.WriteLine("¿lo vuelves a intentar? si/no");

            string answer = Console.ReadLine();

            if (answer == "si")
            {
                Start();
            }
            else if (answer == "no")
            {
                Console.WriteLine("Game Over.");
            }
            else
            {
                Console.WriteLine(" el hada no te entiende ");
            }
        }

    }
}