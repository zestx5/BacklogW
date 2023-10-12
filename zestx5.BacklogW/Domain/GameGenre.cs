using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zestx5.BacklogW.Domain;

namespace zestx5.BacklogW.Domain
{
    public enum GameGenre
    {
        Action,
        Adventure,
        RolePlaying,
        Simulation,
        Strategy,
        Puzzle,
        Racing,
        Sports,
        Fighting,
        Horror,
        Platformer,
        Shooter,
        Music,
        Sandbox,
        Survival,
        Educational,
        Casual,
        MMO,
        Card,
        Board,
        RacingSimulation,
        Tactical,
        Stealth,
        OpenWorld,
        ScienceFiction,
        Fantasy,
        Historical,
        Cyberpunk,
        HorrorSurvival,
        Western,
        Comedy,
        Mystery,
        Superhero,
        Space,
        PostApocalyptic,
        Zombie,
        Pirate,
        War,
        Medieval,
        SportsSimulation,
        VirtualReality,
        AugmentedReality,
        Social,
        BattleRoyale,
        Art,
        Exploration,
        Construction,
        Trading,
        LifeSimulation
    }

}

public static class GameGenreExtensions
{
    public static string GetLabel(this GameGenre genre)
    {
        switch (genre)
        {
            case GameGenre.Action:
                return "Action";
            case GameGenre.Adventure:
                return "Adventure";
            case GameGenre.RolePlaying:
                return "Role-Playing";
            case GameGenre.Simulation:
                return "Simulation";
            case GameGenre.Strategy:
                return "Strategy";
            case GameGenre.Puzzle:
                return "Puzzle";
            case GameGenre.Racing:
                return "Racing";
            case GameGenre.Sports:
                return "Sports";
            case GameGenre.Fighting:
                return "Fighting";
            case GameGenre.Horror:
                return "Horror";
            case GameGenre.Platformer:
                return "Platformer";
            case GameGenre.Shooter:
                return "Shooter";
            case GameGenre.Music:
                return "Music";
            case GameGenre.Sandbox:
                return "Sandbox";
            case GameGenre.Survival:
                return "Survival";
            case GameGenre.Educational:
                return "Educational";
            case GameGenre.Casual:
                return "Casual";
            case GameGenre.MMO:
                return "MMO";
            case GameGenre.Card:
                return "Card";
            case GameGenre.Board:
                return "Board";
            case GameGenre.RacingSimulation:
                return "Racing Simulation";
            case GameGenre.Tactical:
                return "Tactical";
            case GameGenre.Stealth:
                return "Stealth";
            case GameGenre.OpenWorld:
                return "Open World";
            case GameGenre.ScienceFiction:
                return "Science Fiction";
            case GameGenre.Fantasy:
                return "Fantasy";
            case GameGenre.Historical:
                return "Historical";
            case GameGenre.Cyberpunk:
                return "Cyberpunk";
            case GameGenre.HorrorSurvival:
                return "Horror Survival";
            case GameGenre.Western:
                return "Western";
            case GameGenre.Comedy:
                return "Comedy";
            case GameGenre.Mystery:
                return "Mystery";
            case GameGenre.Superhero:
                return "Superhero";
            case GameGenre.Space:
                return "Space";
            case GameGenre.PostApocalyptic:
                return "Post-Apocalyptic";
            case GameGenre.Zombie:
                return "Zombie";
            case GameGenre.Pirate:
                return "Pirate";
            case GameGenre.War:
                return "War";
            case GameGenre.Medieval:
                return "Medieval";
            case GameGenre.SportsSimulation:
                return "Sports Simulation";
            case GameGenre.VirtualReality:
                return "Virtual Reality";
            case GameGenre.AugmentedReality:
                return "Augmented Reality";
            case GameGenre.Social:
                return "Social";
            case GameGenre.BattleRoyale:
                return "Battle Royale";
            case GameGenre.Art:
                return "Art";
            case GameGenre.Exploration:
                return "Exploration";
            case GameGenre.Construction:
                return "Construction";
            case GameGenre.Trading:
                return "Trading";
            case GameGenre.LifeSimulation:
                return "Life Simulation";
            default:
                return "Unknown"; // You can specify a default label if needed
        }
    }
}