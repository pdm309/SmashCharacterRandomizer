using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SmashCharacterRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool satisfied = false;
            Generation gen = generateCharacters();
            while (!satisfied)
            {
                
                Console.WriteLine("\n \nWould you like to generate a new batch of characters for these players?");
                Console.WriteLine("\n \nEnter Y or N");
                string response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                {
                    gen = generateCharacters(gen);
                }
                else
                {
                    satisfied = true;
                    Console.WriteLine("\n \n \n Press Enter to close");
                    Console.ReadLine();
                }
                
            }
        }

        static Generation generateCharacters(Generation gen)
        {
            Random rand = new Random();
            string choice = gen.choice;
            List<string> names = gen.names;
            int number = gen.number;
            List<string> characters = gen.characters;
            //Console.WriteLine(choice + "\n");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("\n");
                List<string> tempCharacters = new List<string>();
                tempCharacters.AddRange(characters);
                //names[i] = names[i].Replace(' ', '\0');
                for (int j = 0; j < number; j++)
                {
                    int randy = rand.Next(tempCharacters.Count);
                    try
                    {
                        string character = tempCharacters[randy];
                        tempCharacters.Remove(character);
                        if (character.Contains(' ') && character.IndexOf(' ') == 0)
                        {
                            character.Remove(0);
                        }
                        Console.WriteLine(names[i] + ": " + character);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(names[i] + ": " + "No more characters left");
                    }

                }
                //Console.WriteLine(names[i] + "\n");
            }
            return gen;
        }

        static Generation generateCharacters()
        {
            Console.WriteLine("Please pick a game between smash64, melee, brawl, project_m, and smash4: \n>");
            Console.WriteLine("Enter choice: ");
            string choice = Console.ReadLine();
            List<string> characters = new List<string>();

            try
            {
                characters = readFile(choice);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
            if (characters == null)
            {
                Console.ReadLine();
                return null;
            }

            Console.WriteLine("Please list the player name(s) seperated by commas: \n>");
            Console.WriteLine("Enter name(s): ");
            char[] splitters = { ',', ' ' };
            string[] nameArray = Console.ReadLine().Split(',');
            List<string> names = new List<string>();
            foreach (string name in nameArray)
            {
                if (name != "" && name != null)
                {
                    if (name.Contains(' ') && name.IndexOf(' ') == 0)
                    {
                        string subName = name.Substring(1);
                        names.Add(subName);
                    }
                    else
                    {
                        names.Add(name);
                    }

                }

            }

            Console.WriteLine("Please write the number of characters each player will get: \n>");
            Console.WriteLine("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Generation gen = new Generation(choice, names, number, characters);
            Random rand = new Random();
            //Console.WriteLine(choice + "\n");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("\n");
                List<string> tempCharacters = new List<string>();
                tempCharacters.AddRange(characters);
                //names[i] = names[i].Replace(' ', '\0');
                for (int j = 0; j < number; j++)
                {
                    int randy = rand.Next(tempCharacters.Count);
                    try
                    {
                        string character = tempCharacters[randy];
                        tempCharacters.Remove(character);
                        if (character.Contains(' ') && character.IndexOf(' ') == 0)
                        {
                            character.Remove(0);
                        }
                        Console.WriteLine(names[i] + ": " + character);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(names[i] + ": " + "No more characters left");
                    }

                }
                //Console.WriteLine(names[i] + "\n");
            }
            return gen;
            
        }

        static List<string> readFile(string choice)
        {
            int counter = 0;
            string line;
            List<string> smash64 = new List<string>();
            List<string> melee = new List<string>();
            List<string> brawl = new List<string>();
            List<string> project_m = new List<string>();
            List<string> smash4 = new List<string>();
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("smashcharacters.txt");
            while ((line = file.ReadLine()) != null)
            {

                switch (counter)
                {
                    case 0: //smash64
                        line = line.Substring(10);
                        string[] splitSmash64 = line.Split(',');
                        for (int i = 0; i < splitSmash64.Length; i++)
                        {
                            smash64.Add(splitSmash64[i]);
                        }
                        break;
                    case 1: //melee
                        line = line.Substring(8);
                        string[] splitMelee = line.Split(',');
                        for (int i = 0; i < splitMelee.Length; i++)
                        {
                            melee.Add(splitMelee[i]);
                        }
                        break;
                    case 2: //brawl
                        line = line.Substring(8);
                        string[] splitBrawl = line.Split(',');
                        for (int i = 0; i < splitBrawl.Length; i++)
                        {
                            brawl.Add(splitBrawl[i]);
                        }
                        break;
                    case 3: //project_m
                        line = line.Substring(12);
                        string[] splitProject_m = line.Split(',');
                        for (int i = 0; i < splitProject_m.Length; i++)
                        {
                            project_m.Add(splitProject_m[i]);
                        }
                        break;
                    case 4: //smash4
                        line = line.Substring(9);
                        string[] splitSmash4 = line.Split(',');
                        for (int i = 0; i < splitSmash4.Length; i++)
                        {
                            smash4.Add(splitSmash4[i]);
                        }
                        break;
                }
                counter++;
            }

            file.Close();

            List<string> characters = new List<string>();
            switch (choice)
            {
                case "smash64":
                    characters = smash64;
                    break;
                case "melee":
                    characters = melee;
                    break;
                case "brawl":
                    characters = brawl;
                    break;
                case "project_m":
                    characters = project_m;
                    break;
                case "smash4":
                    characters = smash4;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine("\n \n \nPress Enter to close");
                    return null;
            }
            return characters;
        }
    }
}
