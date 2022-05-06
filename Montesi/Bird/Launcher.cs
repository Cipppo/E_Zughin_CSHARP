using Montesi.Controller;

namespace Montesi
{
    internal static class Launcher
    {
        private static readonly BirdHandler Bird = new BirdHandler();

        private static void Main()
        {
            Bird.Start();
        }
    }
}