using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    public class Player : IEntity
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }


        public Player(string name)
        {
            Name = name;
            Health = 30;
            Damage = 5;
        }


        public void Attack(IEntity target)
        {
            target.Health -= Damage;
        }


        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}