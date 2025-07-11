using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Data
    {
        private int _number;

        public Data(int number)
        {
            _number = number;
        }
    }
    public class Position
    {
        private int x;
        private int y;
        private int z;

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

        public int Z
        {
            get => z;
            set => z = value;
        }

        public Position(int x, int y, int z)
        {
            this.z = z;
            this.x = x;
            this.y = y;
        }
    }

    internal class Class1
    {
        public static void dudtest() 
        {
            //var x = 123;         //32-bit
            //long l = 1123123132123131321;     //64-bit
            //var l2 = l;
            //float f = 1.1f; //32-bit
            //double d = 1.1; //64-bit
            //decimal dec = 1.1m; // 16-bit

            //double d2 = f;

            bool b = true; // 8-bit

            bool b2 = !b;

            //var ch = '¤';  //32-bit => char is

            //int[] intSet = [1, 2, 3];
            //var integer = intSet[0];

            //double[] doubleSet = [1.1, 1.2, 1.3];

            //var text = "Code with Dudd";

            //var charSet = text.ToCharArray();

            //var text2 = new string(charSet);





            //var A = 1;
            //var g = 'c';
            //var kl = (int)g;
            //var kll = (char)(kl + 1);

            //Console.WriteLine(
            //    $"Character: '{'C'}' => '{(int)'C'}'");




            //text.ToCharArray();
            //if (x == 1)
            //{
            //    //when x is 1'
            //}
            //else if (x == 2)
            //{
            //    //when x is 2
            //}
            //else
            //{
            //    //when x is not 2 or 1
            //    //in other words
            //    // every opther case other than
            //    // 1 or 2
            //}



            Position pos = new Position(1, 2, 3);


            var xxx = pos.X;
            pos.X = 5;
            pos.Y = 3;
            pos.Z = 4;

            var xxx2 = pos.X;

            if (pos.X > 5)

            {
                Console.WriteLine("Position.X is greater than 5");
            }
            else

            {
                Console.WriteLine("Position.X is not greater than 5");
                Console.WriteLine("Position X is " + xxx2);
            }

            //if (pos.X >= 5)
            //{
            //    Console.WriteLine("Position.X is greater or equal to 5");
            //}
            //else
            //{
            //    Console.WriteLine("Position.X is not greater or equal to 5");
            //}

            //if (pos.X < 5)
            //{
            //    Console.WriteLine("Position.X is less than 5");
            //}
            //else
            //{
            //    Console.WriteLine("Position.X is not less than 5");
            //}

            //if (pos.X <= 5)
            //{
            //    Console.WriteLine("Position.X is less or equal to 5");
            //}
            //else
            //{
            //    Console.WriteLine("Position.X is not less or equal to 5");
            //}

            //if (pos.X == 5)
            //{
            //    Console.WriteLine("Position.X is equal to 5");
            //}
            //else
            //{
            //    Console.WriteLine("Position.X is not equal to 5");
            //}

            //if (pos.X != 5)
            //{
            //    Console.WriteLine("Position.X is NOT equal to 5");
            //}
            //else
            //{
            //    Console.WriteLine("Position.X is not NOT equal to 5");
            //}



            //if (pos.X == 12 || pos.Y == 2)
            //{
            //    Console.WriteLine("pos possibly is: [12,2]");
            //}
            //else
            //{
            //    Console.WriteLine("pos is NOT: [12,2]");
            //}

            Console.ReadKey();

   
    }
    }
}
