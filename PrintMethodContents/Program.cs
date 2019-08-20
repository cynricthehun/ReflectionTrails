using System;
using System.ComponentModel;
using System.Reflection;

namespace PrintMethodContents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Paladin newPaladin = new Paladin()
            {
                Height = 5.6,
                Stones = 300
            };

            Warlock newWarlock = new Warlock()
            {
                Height = 5.6,
                Stones = 250
            };

            ICharacterClass convertedCharacter = CharacterClassConversion.ConvertCharacterClass(
                                                newPaladin, 
                                                CharacterClasses.WARLOCK);

            System.Type type = convertedCharacter.GetType();
            PropertyInfo[] myArray = type.GetProperties();

            Console.Write(String.Format("Printing Properties for Object {0} and the namespace {1} \n", type.Name, type.Namespace));
            foreach (PropertyInfo myParam in myArray)
            {
                Console.Write(myParam.Name + "\n");
            }

            ConstructorInfo[] constructorInfo = type.GetConstructors();

            Console.Write("Printing constructors for {0} \n", type.Name);
            foreach (ConstructorInfo constructor in constructorInfo)
            {
                Console.Write(string.Format("{0} \n", constructor));
            }

            MethodInfo[] methodInfo = type.GetMethods();

            Console.Write("Pringing methods for {0} \n", type.Name);
            foreach(MethodInfo method in methodInfo)
            {
                Console.Write(string.Format("{0} \n", method));
            }

            Console.Write("Pringing custom attributes for {0} \n", type.Name);
            foreach (Attribute attribute in type.GetCustomAttributes(true))
            {
                Console.Write(string.Format("{0} \n", attribute));
            }
        }
    }

    enum CharacterClasses
    {
        WARLOCK,
        PALADIN
    }

    class CharacterClassConversion
    {
        public static ICharacterClass ConvertCharacterClass(ICharacterClass originClass, CharacterClasses classType)
        {
            switch (classType)
            {
                case CharacterClasses.WARLOCK:
                    Warlock newWarlock = new Warlock
                    {
                        Height = originClass.Height,
                        Stones = originClass.Stones
                    };

                    return newWarlock;
                case CharacterClasses.PALADIN:
                    Paladin newPaladin = new Paladin
                    {
                        Height = originClass.Height,
                        Stones = originClass.Stones
                    };

                    return newPaladin;
                default:
                    return originClass;
            }
        }
    }

    interface ICharacterClass
    {
        double Height { get; set; }
        double Stones { get; set; }
    }

    class Paladin : ICharacterClass
    {
        public double Height { get; set; }
        public double Stones { get; set; }
    }

    class Warlock : ICharacterClass
    {
        public double Height { get; set; }
        public double Stones { get; set; }
    }
}


