using Microsoft.Owin.Hosting;
using System;

namespace AkkaIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorsEnvironment.ConfigureAndRun();
            WebApp.Start<Startup>("http://+:9000");

            Console.ReadLine();
        }
    }
}
