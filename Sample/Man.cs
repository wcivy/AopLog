using System;

namespace Sample
{
    public class Man : IMan
    {
        public void Run()
        {
            string[] runner = new string[] { "Tom", "Jerry" };
            Console.WriteLine($"{runner[1]} is running fast.");
            Console.WriteLine($"{runner[2]} is the winner!");
        }

        public void Say(string words)
        {
            Console.WriteLine(words);
        }
    }
}
