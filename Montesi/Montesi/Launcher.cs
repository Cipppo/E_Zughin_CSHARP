using System;
using Montesi.Controller;

namespace Montesi
{
    class Launcher
    {
        private static readonly BirdHandler Bird = new BirdHandler();
        
        static void Main(string[] args)
        {
            Bird.Start();
        }
    }
}