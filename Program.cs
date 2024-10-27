using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject5._6._1
{
    internal class Program
    {
        static (string Name, string LastName, byte Age, string[] Pet, string[] favColors) GetInformation()
        {
            (string Name, string LastName, byte Age, string[] Pet, string[] favColors) user;
            Console.WriteLine("Введите свое имя:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите свою фамилию:");
            user.LastName = Console.ReadLine();

            string age;
            byte intage;
            do
            {
                Console.WriteLine("Введите свой возраст:");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));

            user.Age = intage;

            Console.WriteLine("Есть ли у вас домашний питомец (да/нет)?");
            string CheckHasPet = Console.ReadLine().ToLower();
            if (CheckHasPet == "да")
            {
                Console.WriteLine("Сколько у вас питомцев?");
               user.Pet =  GetInfOfPet(byte.Parse(Console.ReadLine()));

            }
            else if (CheckHasPet == "нет")
            {
                user.Pet = Array.Empty<string>(); 
            }
            else
            {
                Console.WriteLine("Неккоректный вариант ответа.");
                user.Pet = Array.Empty<string>(); 
            }
            string countColors;
            byte byteCount;
            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                countColors = Console.ReadLine();
            } while (CheckNum(countColors, out byteCount));
            user.favColors = GetFavColors(byteCount);

            return user;
        }

        static void ShowUser((string Name, string LastName, byte Age, string[] Pet, string[] favColors) user)
        {
            Console.WriteLine($"Имя: {user.Name} | Фамилия: {user.LastName} | Возраст: {user.Age}");
            if (user.Pet == Array.Empty<string>())
            {
                Console.WriteLine("У вас нет питомца.");
            }
            else
            {
                ShowPet(user.Pet);
            }
            ShowColors(user.favColors);
        }

        static string[] GetInfOfPet(byte CountPet)
        {
            if (CountPet > 0)
            {
                string[] Pet = new string[CountPet];
                for (int i = 0; i < CountPet; i++)
                {
                    Console.WriteLine($"Введите кличку {i + 1} питомца:");
                    Pet[i] = Console.ReadLine();
                }
                return Pet;

            }
            else
            {
                Console.WriteLine("У вас нет питомца.");
                string[] Pet = new string[0];
                return Pet;

            }
        }

        static void ShowPet(string[] Pet)
        {
            Console.WriteLine("Клички ваших питомцев: ");
            foreach (var i in Pet)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static string[] GetFavColors(byte CountColors)
        {
            if (CountColors > 0)
            {
                string[] favColors = new string[CountColors];
                for (int i = 0; i < CountColors; i++)
                {
                    Console.WriteLine($"Введите свой {i + 1} любимый цвет: ");
                    favColors[i] = Console.ReadLine();
                }
                return favColors;
            }
            else
            {
                Console.WriteLine("Вы не ввели любимые цвета.");
                string[] favColors = new string[0];

                return favColors;
            }
            
        }

        static void ShowColors(string[] favColors)
        {
            Console.WriteLine("Ваши любимые цвета: ");
            foreach (var color in favColors)
            {
                Console.Write(color + " ");
            }
            Console.WriteLine();
        }

        static bool CheckNum(string number, out byte correctnumber)
        {
            if (byte.TryParse(number, out byte intnum))
            {
                if (intnum > 0)
                {
                    correctnumber = intnum;
                    return false;
                }
            }
            {
                correctnumber = 0;
                return true;
            }
        }

        static void Main(string[] args)
        {
            var user = GetInformation();
            ShowUser(user);            

            Console.ReadKey();
        }
    }
}
