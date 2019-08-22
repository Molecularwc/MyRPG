using System;
using System.IO;

namespace MyRPG3
{
    public class DataHandler
    {
        public DataHandler()
        {
        }

        public void Load(Hero hero)
        {
            bool done = false;
            string item;
            try
            {
                string fileName = string.Format(@"c:\Program Files (x86)\SaveRPG\{0}.cdf", hero.Identifier);
                StreamReader file = new StreamReader(fileName);
                if (fileName == string.Format(@"c:\Program Files (x86)\SaveRPG\{0}.cdf", hero.Identifier))
                {
                    hero.Identifier = file.ReadLine();
                    hero.CurrentHealth = int.Parse(file.ReadLine());
                    hero.MaxHealth = int.Parse(file.ReadLine());
                    hero.CurrentMagic = int.Parse(file.ReadLine());
                    hero.MaxMagic = int.Parse(file.ReadLine());
                    hero.Strength = int.Parse(file.ReadLine());
                    hero.Defense = int.Parse(file.ReadLine());
                    hero.Agility = int.Parse(file.ReadLine());
                    hero.Intelligence = int.Parse(file.ReadLine());
                    hero.Experience = int.Parse(file.ReadLine());
                    hero.CurrentXP = int.Parse(file.ReadLine());
                    hero.XpThresh = int.Parse(file.ReadLine());
                    hero.XpToLevel = int.Parse(file.ReadLine());
                    hero.Gold = int.Parse(file.ReadLine());
                    hero.Level = int.Parse(file.ReadLine());
                    hero.AttackDamage = int.Parse(file.ReadLine());
                    hero.PotionQty = int.Parse(file.ReadLine());
                    while (done == false)
                    {
                        item = file.ReadLine();
                        if (item != null)
                        {
                            hero.items.Add(item);
                        }
                        else
                        {
                            done = true;
                        }
                    }

                    file.Close();
                    Console.WriteLine("Load Successful {0}.", hero.Identifier);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("The file does not exist {0}. You must first make a save file.", hero.Identifier);
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

        public void Save(Hero hero)
        {
            if (Directory.Exists(@"c:\Program Files (x86)\SaveRPG") == false)
            {
                Directory.CreateDirectory(@"c:\Program Files (x86)\SaveRPG");
            }
            string fileName = string.Format(@"c:\Program Files (x86)\SaveRPG\{0}.cdf", hero.Identifier);
            StreamWriter file = new StreamWriter(fileName);

            file.WriteLine(hero.Identifier);
            file.WriteLine(hero.CurrentHealth);
            file.WriteLine(hero.MaxHealth);
            file.WriteLine(hero.CurrentMagic);
            file.WriteLine(hero.MaxMagic);
            file.WriteLine(hero.Strength);
            file.WriteLine(hero.Defense);
            file.WriteLine(hero.Agility);
            file.WriteLine(hero.Intelligence);
            file.WriteLine($"{hero.Experience:F0}");
            file.WriteLine($"{hero.CurrentXP:F0}");
            file.WriteLine(hero.XpThresh);
            file.WriteLine(hero.XpToLevel);
            file.WriteLine($"{hero.Gold:F0}");
            file.WriteLine(hero.Level);
            file.WriteLine(hero.AttackDamage);
            file.WriteLine(hero.PotionQty);
            foreach (string item in hero.items)
            {
                file.WriteLine(item);
            }
            file.Close();
            Console.WriteLine("Game Save successful");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}