using System;
using Zoo.Animals;

namespace Zoo.StatePattern
{
    class StateHungry : StatePattern.State
    {
        public override void Cure(Animal animal)
        {
           // throw new NotImplementedException();
            Console.WriteLine( "I am not sick! I am hungry! Please feed me:)" );
        }

        public override void Downgrade(Animal animal)
        {
            animal.CurrentState=new StateSick();
        }

        public override void Feed(Animal animal)
        {
            animal.CurrentState = new StateFull();
            Console.WriteLine("The animal with alias {0} has been fed!", animal.PetName);
        }

        public override void Remove(Animal animal)
        {
            Console.WriteLine("You cannot remove me from the zoo! I am alive!");
        }
    }
}
