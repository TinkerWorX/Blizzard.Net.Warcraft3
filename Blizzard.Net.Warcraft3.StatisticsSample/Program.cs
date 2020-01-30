using System;
using System.Threading;

namespace Blizzard.Net.Warcraft3.Statistics
{
    internal class Program
    {
        internal static unsafe void Main(string[] args)
        {
            ObserverData file = null;

            while (true)
            {
                if (file == null)
                {
                    if (!ObserverData.TryOpen(out file))
                    {
                        Console.Clear();
                        Console.Write("Warcraft III is not running, waiting a second to try again . . .");
                        Thread.Sleep(1000);
                        continue;
                    }

                    // set the refresh rate to 200 to enable the observer api
                    file.RefreshRate = 200;
                }
                else
                {
                    if (file.RefreshRate > 0)
                    {
                        file.RefreshRate = 200;

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
                    else
                    {
                        file.Dispose();
                        file = null;
                    }

                }
            }
        }
    }
}
