using Zoo.Animals;

namespace Zoo.StatePattern
{
    abstract class State
    {
        //Base class for implementing State Pattern of GoF design patterns
        public abstract void Feed(Animal animal);
        public abstract void Cure(Animal animal);
        public abstract void Remove(Animal animal);
        public abstract void Downgrade(Animal animal);
    }
}
