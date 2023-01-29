using System.Reflection.PortableExecutable;

namespace sadnadrill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input;
            while (true)
            {
                Console.WriteLine("please chosse action : \n 1)add person \n 2) remove person \n 3)search by hobby \n 4) search by charcacteristics\n 5) print all \n 6) search by range ages ");
                input = Console.ReadLine();
                if (input == "1")
                {
                    createPerson(persons);
                }
                else if (input == "2")
                {
                    removerPerson(persons);

                }
                else if (input == "3")
                {
                    searchByHobby(persons);
                }
                else if (input == "4")
                {
                    searchBycharcacter(persons);
                }
                else if (input == "5")
                {
                    foreach (Person person in persons)
                    {
                        Console.WriteLine($"name : {person.Name} age : {person.age} id: {person.id}");
                    }
                }
                else if (input == "6")
                {
                    searchByAge(persons);
                }
            }

        }
        static void createPerson(List<Person> persons)
        {
            string name, age, id, hobby, character, hours;
            int ageForCreate;
            double hoursForCreate;
            Console.WriteLine("enter name");
            name = Console.ReadLine();
            while (!isValidInput(name))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                name = Console.ReadLine();
            }
            Console.WriteLine("enter age");
            age = Console.ReadLine();
            while (!(int.TryParse(age, out ageForCreate)))
            {
                Console.WriteLine("Input is not a valid integer.\n please enter again");
                age = Console.ReadLine();
            }
            Console.WriteLine("enter id");
            id = Console.ReadLine();
            while (!isValidInput(id))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                id = Console.ReadLine();
            }

            Console.WriteLine("enter hobby");
            hobby = Console.ReadLine();
            while (!isValidInput(hobby))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                hobby = Console.ReadLine();
            }
            Console.WriteLine("enter hours");
            hours = Console.ReadLine();
            while (!(double.TryParse(hours, out hoursForCreate)))
            {
                Console.WriteLine("Input is not a valid integer.\n please enter again");
                hours = Console.ReadLine();
            }
            Console.WriteLine("enter character");
            character = Console.ReadLine();
            while (!isValidInput(character))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                character = Console.ReadLine();
            }
            Person newper = new(name, ageForCreate, id, hobby, hoursForCreate, character);
            persons.Add(newper);

        }
        static bool isValidInput(string input)
        {
            if (input.Length == 0)
                return false;
            return true;
        }
        static void removerPerson(List<Person> persons)
        {
            string id;
            Console.WriteLine("enter id for remove");
            id = Console.ReadLine();
            while (!isValidInput(id))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                id = Console.ReadLine();
            }
            foreach (Person person in persons)
            {
                if (person.id == id)
                {
                    persons.Remove(person);
                    Console.WriteLine("person removed!!!");
                    return;
                }
            }
            Console.WriteLine("this person does not exit");
        }
        static void searchByHobby(List<Person> persons)
        {
            string input;
            Console.WriteLine("enter a hobyy that you want searchBy");
            input = Console.ReadLine();
            while (!isValidInput(input))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                input = Console.ReadLine();
            }
            foreach (Person person in persons)
            {
                if (person.hobbies.ContainsKey(input))
                {
                    Console.WriteLine(person.Name + " has this hobby and he investor " + person.hobbies[input] + " hours in a week ");
                }
            }
        }
        static void searchBycharcacter(List<Person> persons)
        {
            string input;
            Console.WriteLine("enter a character that you want searchBy");
            input = Console.ReadLine();
            while (!isValidInput(input))
            {
                Console.WriteLine("Input is not a valid .\n please enter again");
                input = Console.ReadLine();
            }
            foreach (Person person in persons)
            {
                if (person.charcacteristics.Contains(input))
                {
                    Console.WriteLine(person.Name + " has this character ");
                }
            }
        }
        static void searchByAge(List<Person> persons)
        {
            string input;
            string input2;
            Console.WriteLine("enter a min age that you want searchBy");
            input = Console.ReadLine();
            Console.WriteLine("enter a max age that you want searchBy");
            input2 = Console.ReadLine();
            foreach (Person person in persons)
            {
                if (person.age > int.Parse(input) && person.age < int.Parse(input2))
                {
                    Console.WriteLine(person.Name + " in this range ");
                }
            }
        }

    }
    class Person
    {
        public string Name { get; set; } = "anonymous";
        public int age { get; set; }
        public string id { get; set; }
        public List<string> charcacteristics { get; set; }
        public Dictionary<string, double> hobbies { get; set; }
        public Person(string name, int age, string id, string hobby, double hours, string character)
        {
            this.Name = name;
            this.age = age;
            this.id = id;
            this.charcacteristics = new() { character };
            this.hobbies = new();
            this.hobbies.Add(hobby, hours);

            /* this.hobby = hobby;
             this.hours = hours;
             this.character = character;*/
        }
    }
}