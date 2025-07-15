using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Lessons
{
    internal class Class2
    {
        public static void lesson2()
        {
            //string command = Console.ReadLine();

            //if (command == "Class1")
            //{
            //    Class1.dudtest();
            //}

            //int i = 5;
            //string dud = "test";

            //int b = 6;
            //int[] test1 = [1, 3, 4];
            //TestClass testClass = new TestClass(21);
            //var testClass1 = new TestClass(22);

            //Console.WriteLine(testClass.Value);
            //Console.WriteLine(testClass1.Value);

            //TestClass[] tttst = [testClass, testClass1];
            //tttst[0].Value = 42;
            //tttst[1].Value = 15;
            //Console.WriteLine(testClass.Value);


            int b = 55;
            int a = 1;
            TestClass testClass = new TestClass(b);  //  give value 55 to the testClass
            var testClass1 = new TestClass(a); // give value 1 to testClass1 

            Console.WriteLine(testClass1.Value); // print 1
            Console.WriteLine(testClass.Value);  // print 55

            TestClass[] tttst = [testClass, testClass1]; //create new array 
            tttst[0].Value = a; // give value to testClass = 1
            tttst[1].Value = b; //give value to testClass1 = 55
            Console.WriteLine(testClass1.Value); //print 55
            Console.WriteLine(testClass.Value); // print 1

            int dud = testClass.Method2(10);
            Console.WriteLine(dud); //print 10

            if (dud == 10)
            {
                int number = 15;
                Console.WriteLine(number);
                if (number == 15)
                {
                    Console.WriteLine(number);
                    int dud2 = testClass.Method2(22);
                    {
                        int number2 = 12;
                    }
                }
            }

            Console.ReadKey();



            //if (testClass.Value <= 15)
            //{
            //    Console.WriteLine("testdud");
            //}
            //else
            //{
            //    Console.WriteLine("nope");
            //}

            int Method(int m, int n) // define Method with 2 parameters m and n
            {
                //m = 3;  //assign 3 to m
                // n = 6;  // assign 6 to n
                return m - n; // add m to n and return
            }

            int method = Method(3, 6); // call method with parameters 3 and 6

            Console.WriteLine(method); // 9

            int method2 = Method(5, 6);

            Console.WriteLine(method2); // 11

            Console.ReadKey();


            //void Method(int m)
            //{
            //    Console.WriteLine(m);
            //    if (m < 20)
            //        Method(m + 1);
            //}

            //Method(15);


            List<string> strings = new List<string>(); //create a list of strings

            foreach (string testloop in strings) // loop through strings in the list
            {
                Console.WriteLine(testloop); 
            }

            strings.Add("testlooooop");

            foreach (string testloop in strings)
            {
                Console.WriteLine(testloop);
            }

            strings.Remove("testlooooop");

            foreach (string testloop in strings)
            {
                Console.WriteLine(testloop);
            }
        }



class TestClass
        {
            public int Value
            {
                get;
                set;
            }
            public TestClass(int z)
            {
                Value = z;
            }

            public int Method2(int m)
            {
                return m * Value;
            }
        }


    }
}

