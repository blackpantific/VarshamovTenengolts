using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarshamovTenengolts
{
    class Program
    {
        public static List<int> UsersNWord { get; set; } = new List<int>();
        public static int PositionToRemove { get; set; }
        public static int RemovedNumber { get; set; }
        public static int PositionToInsert { get; set; }
        public static int NumberToInsert { get; set; }

        static void Main(string[] args)
        {
            while (true)
            {


                while (true)
                {
                    Console.WriteLine("Enter n-word: ");
                    var str = Console.ReadLine();
                    var listOfInt = StringToIntList(str);
                    var sumOfPositions = 0;
                    for (int i = 0; i < listOfInt.Count; i++)
                    {
                        if (listOfInt[i] == 1)
                        {
                            sumOfPositions += i + 1;
                        }
                    }

                    var modRes = sumOfPositions % (listOfInt.Count + 1);
                    if (modRes == 0)
                    {
                        UsersNWord = listOfInt;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong n-word, try again!");
                    }


                }

                Console.WriteLine("Enter 1 to remove element, 2 to insert: ");
                var choise = Console.ReadLine();

                if (Convert.ToInt32(choise) == 1)
                {
                    RemoveNumberMethod();
                }
                else
                {
                    AddNumber();
                }
            }

            //Console.ReadKey();
        }


        public static List<int> StringToIntList(string binaryStr)
        {
            var charArray = binaryStr.ToCharArray();
            List<int> listToReturn = new List<int>();
            foreach (var item in charArray)
            {
                listToReturn.Add(Convert.ToInt32(item.ToString()));
            }
            return listToReturn;
        }
        public static int PositionReturn()
        {
            while (true)
            {
                Console.WriteLine("Enter position to remove: ");
                var position = Console.ReadLine();
                if (Convert.ToInt32(position) > UsersNWord.Count)
                {
                    Console.WriteLine("The position is out of array range!");
                }
                else
                {
                    return Convert.ToInt32(position);
                }
            }
        }
        public static void RemoveNumberMethod()
        {
            PositionToRemove = PositionReturn();

            var truncatedArray = new List<int>(UsersNWord);
            truncatedArray.RemoveAt(PositionToRemove - 1);
            Console.WriteLine(ArrayTostring(truncatedArray));

            var sumOfSPrimeArray = 0;
            for (int i = 0; i < truncatedArray.Count; i++)
            {
                if (truncatedArray[i] == 1)
                {
                    sumOfSPrimeArray += (i + 1);
                }
            }

            var sPrimeModValue = (truncatedArray.Count + 2 - sumOfSPrimeArray % (truncatedArray.Count + 2))%(truncatedArray.Count + 2); // n + 1 - a mod (n + 1) try to mod(n+1)

            Console.WriteLine($"S' = {sumOfSPrimeArray}");
            Console.WriteLine($"(-S')(mod(n+1)) = {sPrimeModValue}");

            var numberOfOneValues = 0;

            for (int i = 0; i < truncatedArray.Count; i++)
            {
                if (truncatedArray[i] == 1)
                {
                    numberOfOneValues += 1;
                }
            }
            Console.WriteLine($"||a'|| = {numberOfOneValues}");
            if (numberOfOneValues >= sPrimeModValue)
            {
                RemovedNumber = 0;
                Console.WriteLine($"Removed number: {RemovedNumber}");
                Console.WriteLine($"||a'|| >= {sPrimeModValue}");
            }
            else
            {

                RemovedNumber = 1;
                Console.WriteLine($"Removed number: {RemovedNumber}");
                Console.WriteLine($"||a'|| < n - {UsersNWord.Count - sPrimeModValue}");
            }

            if (RemovedNumber == 0)
            {
                Console.WriteLine($"n_1 = {sPrimeModValue}");
            }
            else
            {
                Console.WriteLine($"n_0 = {UsersNWord.Count - sPrimeModValue}");
            }

        }
        public static void AddNumber() 
        {

            while (true)
            {
                Console.WriteLine("Enter position to insert: ");
                var position = Console.ReadLine();
                if (Convert.ToInt32(position) > UsersNWord.Count || Convert.ToInt32(position) == 0)
                {
                    Console.WriteLine("The position is out of array range!");
                }
                else
                {
                    PositionToInsert = Convert.ToInt32(position);
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter number to insert: ");
                var insertedNumber = Console.ReadLine();
                if (Convert.ToInt32(insertedNumber) == 0 || Convert.ToInt32(insertedNumber) == 1)
                {
                    NumberToInsert = Convert.ToInt32(insertedNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Number is wrong!");
                }
            }

            var newArray = new List<int>(UsersNWord);
            newArray.Insert(PositionToInsert - 1, NumberToInsert);
            Console.WriteLine(ArrayTostring(newArray));

            var sumPositionsOneNumber = 0;

            for (int i = 0; i < newArray.Count; i++)
            {
                if (newArray[i] == 1)
                {
                    sumPositionsOneNumber += i + 1;
                }
            }

            var T = sumPositionsOneNumber % (newArray.Count);
            Console.WriteLine($"T = ({sumPositionsOneNumber})mod({newArray.Count}) = {T}");
            var a = 0;

            for (int i = 0; i < newArray.Count; i++)
            {
                if (newArray[i] == 1)
                {
                    a += 1;
                }
            }

            Console.WriteLine($"||a'|| = {a}");

            if (T == 0)
            {
                var n_1 = 0;//remove last number from a'
                Console.WriteLine("n_1 = 0, remove last number from a'");
            }
            else if (T == a)
            {
                var n_1 = 0;//remove first number from a'
                Console.WriteLine("n_1 = 0, remove first number from a'");
            }
            else if (T > 0 && T != a)
            {
                if (T < a)
                {
                    var n_1 = T;
                    Console.WriteLine($"n_1 = {n_1} = T");
                }
                else
                {
                    var n_0 = UsersNWord.Count + 1 - T;
                    Console.WriteLine($"n_0 = {UsersNWord.Count} + 1 - {T} = {n_0}");
                }
            }
        }
        public static string ArrayTostring(List<int> list)
        {
            var str = "";
            foreach (var item in list)
            {
                str += Convert.ToString(item);
            }
            return str;
        }
    }
}
