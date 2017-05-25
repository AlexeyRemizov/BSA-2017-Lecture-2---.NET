using System;
using System.Threading;
using Zoo.Animals;

namespace Zoo.StatePattern
{
    class StateSick : State
    {
        public override void Cure(Animal animal)
        {
            if (animal.Health < animal.MaxHealth)
            {
                animal.Health++;
                Console.WriteLine("The {0} has been cured to health {1}", animal.PetName, animal.Health);
            }
            else { Console.WriteLine("The {0} has maximum health {1}", animal.PetName, animal.MaxHealth);}
        }

        public override void Downgrade(Animal animal)
        {
            if (animal.Health > 1)
            {
                animal.Health--;
            }
            else
            {
                animal.CurrentState=new StateDead();
                animal.Health = 0;
                animal.Zoo.DeadAnimals++;
                if (animal.Zoo.DeadAnimals==animal.Zoo.Animals.Count)
                {
                    Console.Beep();
                    Console.WriteLine("There isn't any alive animal in the zoo.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                animal.Zoo.Animals.Remove(animal);
                animal.Zoo.Animals.Add(animal);
            }
        }

        public override void Feed(Animal animal)
        {
            Console.WriteLine("\nI'm sick! Please, cure me!\n");
        }

        public override void Remove(Animal animal)
        {
            Console.WriteLine("\nI'm alive! You can't remove me\n");
        }
    }
}
