using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    public class Enemy : IEntity
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public void Attack(IEntity target)
        {
            target.Health -= Damage;//acortado de target.Health = target.Health - Damage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}