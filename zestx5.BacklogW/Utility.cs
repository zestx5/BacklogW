using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zestx5.BacklogW.Domain.Entities;

namespace zestx5.BacklogW
{
    internal static class Utility
    {
        public static List<Game> GenerateStubData() => new()
            {
                new Game("Remnant 2",GameStatus.Playing,new List<GameGenre>{GameGenre.Action,GameGenre.Shooter,GameGenre.RolePlaying}),
                new Game("The Last Of Us",GameStatus.Planned,new List<GameGenre>{GameGenre.Action,GameGenre.Adventure,GameGenre.PostApocalyptic}),
                new Game("Ratchet & Clank: Rift Apart",GameStatus.Paused,new List<GameGenre>{GameGenre.Action,GameGenre.Adventure,GameGenre.Platformer}),
                new Game("Cyberpunk 2077",GameStatus.Playing,new List<GameGenre>{GameGenre.Action,GameGenre.Shooter,GameGenre.RolePlaying,GameGenre.Cyberpunk}),
                new Game("Assassin's Creed Odyssey",GameStatus.Playing,new List<GameGenre>{GameGenre.Action,GameGenre.OpenWorld,GameGenre.RolePlaying}),
            };
    }
}
