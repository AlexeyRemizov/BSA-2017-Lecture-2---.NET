using System;
using System.Linq;
using Zoo.Animals;
using System.Threading;

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
			===========================
			5 - Exit
			===========================");

			var value = Console.ReadLine();
			if (!int.TryParse(value, out result) || result > 5 || result < 1)
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
					case 5:
						Console.WriteLine("With best regards!!! Your zoo");
						Thread.Sleep(3000);
						Environment.Exit(0);
						break;
				}
			}


		}

		void AddAnimal()
        {
			int result;
            Console.WriteLine(@"Enter a new animal or exit: 
		=====================
		1 - Bear	
		=====================
		2 - Elephant
		=====================
		3 - Fox
		=====================
		4 - Lion
		=====================
		5 - Tiger
		=====================
		6 - Wolf
		=====================");
			var value = Console.ReadLine();

			if (!int.TryParse(value, out result) || result > 7 || result < 1)
            {
                Console.WriteLine("\n Incorrect value!\n");
            }
            else
            {
                Console.WriteLine("\nEnter the animal's pet name.");
                var petname = Console.ReadLine();
				if (zoo.Animals.Any(x => x.PetName == petname))
				{
					Console.WriteLine("\nThe animal with pet name {0} exists\n", petname);
					return;
				}
				if (petname.Length > 10 || petname.Length == 0 )
                {
                    Console.WriteLine("\nThe pet name should not be longer then 10 symbols or be empty!");
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
					case 7:
						Console.WriteLine("With best regards!!! Your zoo");
						Thread.Sleep(3000);
						Environment.Exit(0);
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
