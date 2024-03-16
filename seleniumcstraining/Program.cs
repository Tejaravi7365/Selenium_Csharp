using System.Security.Cryptography.X509Certificates;

namespace seleniumcstraining
{
    class Program
    {
        public void getData()
        {
            Console.WriteLine("I am inside the main program");
        }
        static void Main(string[] args)
        {
            Program P = new Program();
            P.getData();

            Console.WriteLine("Hello, World!");

            int a = 4;
            Console.WriteLine(a);

            string name = "Ravi";
            Console.WriteLine("My name is " + name);

            var age = 6; 
            Console.WriteLine($"My age is {age}");


        }
    }
}
