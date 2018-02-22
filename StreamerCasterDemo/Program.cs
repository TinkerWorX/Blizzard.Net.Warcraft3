using System;
using System.Threading;
using Blizzard.Net.Warcraft3.Statistics;

namespace StreamerCasterDemo
{
    internal class Program
    {
        internal static unsafe void Main(string[] args)
        {
            var file = ObserverData.Open();

            // set the refresh rate to the minimum of 200, which is 5 times per second.
            file->RefreshRate = 200;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Version:         " + file->Version);
                Console.WriteLine("RefreshRate:     " + file->RefreshRate);
                Console.WriteLine("IsInGame:        " + file->Game.IsInGame);
                Console.WriteLine("GameName:        " + file->Game.GameName);
                Console.WriteLine("MapName:         " + file->Game.MapName);
                Console.WriteLine("NumberOfPlayers: " + file->Game.NumberOfPlayers);
                Console.WriteLine("GameTime:        " + file->Game.GameTime);

                foreach (var player in file->Players)
                {
                    if (player.SlotState == PlayerSlotState.Empty)
                        continue;
                    Console.WriteLine($"[Id={player.Id}] [N={player.Name}] [G={player.Gold}] [L={player.Lumber}] [F={player.FoodUsed}/{player.FoodCap}] [CL={player.TeamColor}] [T={player.TeamIndex}] [HC={player.Handicap}] [AI={player.AiDifficulty}] [PT={player.Type}]");
                }

                Thread.Sleep((int)file->RefreshRate);
            }
        }
    }
}
