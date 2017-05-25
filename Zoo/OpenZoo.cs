using System;
using System.Linq;
using Zoo.Animals;

namespace Zoo.OpenZoo
{
    class Open
    {
        Zoo zoo;
        public void Start()
        {
            Console.WriteLine("Welcome to the new world of aminal - Zoo of Dead!\n");
			Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n");
			zoo = new Zoo();
            while (true)
            {
                if (zoo.Animals.Count == 0)
                {
                    AddAnimal();
                }
                else SelectOperation();
            } 
        }

		void SelectOperation()
		{
			int result;
			Console.WriteLine(@"Perform the following operations:
			===========================
			1 - Add new animal
			===========================
			2 - Feed the animal
			===========================
			3 - Cure the animal
			===========================
			4 - Remove the dead animal
			===========================");

			var value = Console.ReadLine();
			if (!int.TryParse(value, out result) || result > 4 || result < 1)
			{
				Console.WriteLine("Incorrect value!");
			}
			else
			{

				switch (result)
				{
					case 1:
						AddAnimal();
						break;
					case 2:
						FindbyPetName()?.Feed();
						break;
					case 3:
						FindbyPetName()?.Treat();
						break;
					case 4:
						FindbyPetName()?.Remove();
						break;
				}
			}


		}

		void AddAnimal()
        {
			int result;
            Console.WriteLine("Enter a new animal: 1 - Bear, 2 - Elephant, 3 - Fox, 4- Lion, 5 - Tiger, 6 - Wolf");
			var value = Console.ReadLine();
			if (!int.TryParse(value, out result) || result > 6 || result < 1)
            {
                Console.WriteLine("\n Incorrect value!\n");
            }
            else
            {
                Console.WriteLine("\nPlease, enter the animal's pet name.");
                var petname = Console.ReadLine();

				if (petname.Length > 10 || petname.Length == 0 )
                {
                    Console.WriteLine("\nThe pet name should not be longer then 10 symbols or be empty!");
                    return;
                }

				if (zoo.Animals.Any(x => x.PetName == petname))
                {
                    Console.WriteLine("\nThe animal with pet name {0} already exists\n", petname);
                    return;
                }
                switch (result)
                {
                    case 1:
                        zoo.Animals.Add(new Bear(petname, zoo));
                        break;
                    case 2:
                        zoo.Animals.Add(new Elephant(petname, zoo));
                        break;
                    case 3:
                        zoo.Animals.Add(new Fox(petname, zoo));
                        break;
                    case 4:
                        zoo.Animals.Add(new Lion(petname, zoo));
                        break;
                    case 5:
                        zoo.Animals.Add(new Tiger(petname, zoo));
                        break;
                    case 6:
                        zoo.Animals.Add(new Wolf(petname, zoo));
                        break;
					default:
						break;
                }
                Console.WriteLine("The animal has been added!");
            }
        }

        Animal FindbyPetName()
        {
			Console.WriteLine("Pet name is");
            var petname = Console.ReadLine();
            var animal = zoo.Animals.FirstOrDefault(x => x.PetName == petname);
            if (animal == null)
            {
                Console.WriteLine("There is no animal with pet name {0} ", petname);
                return null;
            }
            else return animal;
        }

        
    }
}
