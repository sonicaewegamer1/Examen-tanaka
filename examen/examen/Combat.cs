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


            while (player.IsAlive() &&
                  enemy.IsAlive())
            {
                player.Attack(enemy);

                if (enemy.IsAlive())
                {
                    enemy.Attack(player);
                }
            }

            return player.IsAlive();
        }
    }
}