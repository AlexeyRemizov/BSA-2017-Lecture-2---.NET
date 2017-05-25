using System;
using Zoo.Animals;

namespace Zoo.StatePattern
{
    class StateFull : StatePattern.State
    {
        public override void Cure(Animal animal)
        {
            Console.WriteLine("\nI'm healthy! Don't cure me!\n");
        }

        public override void Downgrade(Animal animal)
        {
           animal.CurrentState=new StateHungry();
        }

        public override void Feed(Animal animal)
        {
            Console.WriteLine("\nI'm not hungry. Don't feed me:)\n");
        }

        public override void Remove(Animal animal)
        {
            Console.WriteLine("\nI'm alive! You can't remove me!\n");
        }
    }
}
