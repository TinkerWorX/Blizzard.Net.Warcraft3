using System;
using System.Threading;

namespace Blizzard.Net.Warcraft3.Statistics
{
    internal class Program
    {
        internal static unsafe void Main(string[] args)
        {
            var file = new ObserverData();

            // set the refresh rate to the minimum of 200, which is 5 times per second.
            file.RefreshRate = 200;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Version:         " + file.Version);
                Console.WriteLine("RefreshRate:     " + file.RefreshRate);
                Console.WriteLine("IsInGame:        " + file.Game->IsInGame);
                Console.WriteLine("GameName:        " + file.Game->GameName);
                Console.WriteLine("MapName:         " + file.Game->MapName);
                Console.WriteLine("NumberOfPlayers: " + file.Game->NumberOfPlayers);
                Console.WriteLine("GameTime:        " + file.Game->GameTime);

                Console.WriteLine(file.Players[0].Name);
                Console.WriteLine(file.Players[1].Name);
                Console.WriteLine(file.Shops.Length + " shops:");
                foreach (ref var shop in file.Shops)
                {
                    Console.WriteLine(" * " + shop.Name);
                }

                Thread.Sleep((int)file.RefreshRate);
            }
        }
    }
}
