using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetShopp
{
    class Cat
    {
        public int Id { get; set; }
        static public int MyID { get; set; } = 0;
        public string Nickname { get; set; } = String.Empty;
        public int Age { get; set; } = 0;
        public string Gender { get; set; } = String.Empty;
        public int Energy { get; set; } = 10;
        public int Price { get; set; } = 0;
        public int MealQuantity { get; set; } = 0;
        public int GrowUP { get; set; } = 0;
        public Cat()
        {
            Id = ++MyID;
        }
        public Cat(string nickname, int age, string gender, int price, int mealQuantity)
        {
            Id = ++MyID;
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Price = price;
            MealQuantity = mealQuantity;
        }
        public void Eat()
        {
            if (Energy >= 10)
            {
                Console.WriteLine("I'm full, i want to play (❁´◡`❁)");
            }
            else
            {
                if (GrowUP == 5)
                {
                    ++Age;
                    GrowUP = 0;
                    Price += 3;
                    ++MealQuantity;
                }
                else
                {
                    ++Energy;
                    ++GrowUP;
                }
            }

        }
        public void Sleep()
        {
            if (Energy >= 10)
            {
                Console.WriteLine("I'm not sleepy, i want to play (❁´◡`❁)");
            }
            else
            {
                ++Energy;
            }
        }
        public void Play()
        {
            if (Energy > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm so hungry (⊙_⊙;) ");
                Console.WriteLine("Please give me something to eat ...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (Energy <= 0)
            {
                Sleep();
                Console.WriteLine("I'm sleeping zzzzzzzzzzzzzzzzzz  zzzzzzz  zzzzzzzz");
            }
            --Energy;

        }
        public void ShowCat()
        {
            Console.WriteLine($"             [{Id}] {Nickname}      Age: {Age}       Gender:{Gender}");
            Console.WriteLine($"             Energy: {Energy} ");
            Console.WriteLine($"             Meal Quntity: {MealQuantity}g ");
            Console.WriteLine($"             Price: {Price} $\n");
        }
    }

    class CatHouse
    {
        public int Id { get; set; }
        public int MyID { get; set; } = 0;
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; } = 0;

        public CatHouse()
        {
            Id = ++MyID;
        }
        public void AddCat(Cat cat)
        {
            var temp = new Cat[CatCount + 1];
            if (CatCount != 0)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;
            ++CatCount;
        }
        public void RemoveByNickname(string nickname)
        {
            var temp = new Cat[CatCount - 1];
            for (int i = 0, k = 0; i < CatCount; k++, i++)
            {
                if (Cats[i].Nickname == nickname)
                {
                    ++i;
                }
                temp[k] = Cats[i];
            }
            Cats = temp;
            --CatCount;
        }
        public void ShowCats()
        {
            for (int i = 0; i < CatCount; i++)
            {
                Cats[i].ShowCat();
            }
        }
    }

    class PetShop
    {
        public CatHouse[] CatHouses { get; set; }
        public int HousesCount { get; set; }

        public void AddHouse(CatHouse house)
        {
            var temp = new CatHouse[HousesCount + 1];
            if (HousesCount != 0)
            {
                CatHouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = house;
            CatHouses = temp;
            HousesCount++;
        }
        public int GetTotalPetPrice()
        {
            int total = 0;
            for (int i = 0; i < HousesCount; i++)
            {
                var count = CatHouses[i].CatCount;
                for (int k = 0; k < count; k++)
                {
                    total += CatHouses[i].Cats[k].Price;
                }
            }
            return total;
        }
        public int GetTotalMealQuantity()
        {
            int total = 0;
            for (int i = 0; i < HousesCount; i++)
            {
                var count = CatHouses[i].CatCount;
                for (int k = 0; k < count; k++)
                {
                    total += CatHouses[i].Cats[k].MealQuantity;
                }
            }
            return total;
        }
        public void ShowPetshop()
        {
            for (int i = 0; i < HousesCount; i++)
            {
                Console.WriteLine($"<<<<<<<<<<<<<<<<<< House [{i}] >>>>>>>>>>>>>>>>>");
                CatHouses[i].ShowCats();
            }
        }
    }

    class Program
    {
        class Run
        {
            public PetShop CreatCats()
            {
                Cat cat1 = new Cat
                {
                    Nickname = "Tom",
                    Age = 2,
                    Gender = "M",
                    Price = 500,
                    MealQuantity = 35
                };
                Cat cat2 = new Cat
                {
                    Nickname = "Mestan",
                    Age = 1,
                    Gender = "F",
                    Price = 200,
                    MealQuantity = 40
                };
                Cat cat3 = new Cat
                {
                    Nickname = "Casper",
                    Age = 4,
                    Gender = "M",
                    Price = 700,
                    MealQuantity = 65
                };
                Cat cat4 = new Cat
                {
                    Nickname = "Hazel",
                    Age = 1,
                    Gender = "F",
                    Price = 800,
                    MealQuantity = 20
                };
                Cat cat5 = new Cat
                {
                    Nickname = "Tiger",
                    Age = 3,
                    Gender = "M",
                    Price = 700,
                    MealQuantity = 65
                };

                CatHouse cathouse1 = new CatHouse();
                cathouse1.AddCat(cat1);
                cathouse1.AddCat(cat2);

                CatHouse cathouse2 = new CatHouse();
                cathouse2.AddCat(cat3);
                cathouse2.AddCat(cat4);

                CatHouse cathouse3 = new CatHouse();
                cathouse3.AddCat(cat5);


                PetShop petShop = new PetShop();
                petShop.AddHouse(cathouse1);
                petShop.AddHouse(cathouse2);
                petShop.AddHouse(cathouse3);

                return petShop;
            }
            public void Display()
            {
                Console.Write($@"                                 Welcome to PetShop.                      
                       Show cats [0]
                       Please choose: ");

                string choise = Console.ReadLine();
                if (choise == "0")
                {
                    var petshop = CreatCats();
                    petshop.ShowPetshop();
                    Display2(petshop);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong created...");
                    Display();
                }

            }
            public void Display2(PetShop petshop)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("Choise cat (ID): ");
                string ID = Console.ReadLine();
                int id = int.Parse(ID);

                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                for (int i = 0; i < petshop.HousesCount; i++)
                {
                    var count = petshop.CatHouses[i].CatCount;
                    for (int k = 0; k < count; k++)
                    {
                        var cat = petshop.CatHouses[i].Cats[k];
                        if (id == cat.Id)
                        {
                            cat.ShowCat();
                            Display3(petshop, cat);
                        }
                    }
                }
            }
            public void Display3(PetShop petshop, Cat cat)
            {
                bool control = true;
                var choise = Choise();
                while (control)
                {
                    if (choise == "1")
                    {

                        cat.Play();
                        choise = Choise();
                    }
                    else if (choise == "2")
                    {

                        cat.Eat();
                        choise = Choise();
                    }
                    else if (choise == "3")
                    {

                        cat.Sleep();
                        choise = Choise();
                    }
                    else if (choise == "0")
                    {

                        Display2(petshop);
                        control = false;
                    }
                }
            }
            public string Choise()
            {
                Console.WriteLine("Playing [1] ");
                Console.WriteLine("Feeding  [2]");
                Console.WriteLine("Sleeping [3]");
                Console.WriteLine("Back [0]");
                Console.Write("Choise: ");
                string choise = Console.ReadLine();
                return choise;
            }
        }
        static void Main(string[] args)
        {
            Run run = new Run();
            run.Display();
        }
    }
}
