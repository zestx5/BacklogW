namespace zestx5.BacklogW.Domain.Entities
{
    public static class GameGenreExtensions
    {
        public static string GetLabel(this GameGenre genre)
        {
            return genre switch
            {
                GameGenre.Action => "Action",
                GameGenre.Adventure => "Adventure",
                GameGenre.RolePlaying => "Role-Playing",
                GameGenre.Simulation => "Simulation",
                GameGenre.Strategy => "Strategy",
                GameGenre.Puzzle => "Puzzle",
                GameGenre.Racing => "Racing",
                GameGenre.Sports => "Sports",
                GameGenre.Fighting => "Fighting",
                GameGenre.Horror => "Horror",
                GameGenre.Platformer => "Platformer",
                GameGenre.Shooter => "Shooter",
                GameGenre.Music => "Music",
                GameGenre.Sandbox => "Sandbox",
                GameGenre.Survival => "Survival",
                GameGenre.Educational => "Educational",
                GameGenre.Casual => "Casual",
                GameGenre.MMO => "MMO",
                GameGenre.Card => "Card",
                GameGenre.Board => "Board",
                GameGenre.RacingSimulation => "Racing Simulation",
                GameGenre.Tactical => "Tactical",
                GameGenre.Stealth => "Stealth",
                GameGenre.OpenWorld => "Open World",
                GameGenre.ScienceFiction => "Science Fiction",
                GameGenre.Fantasy => "Fantasy",
                GameGenre.Historical => "Historical",
                GameGenre.Cyberpunk => "Cyberpunk",
                GameGenre.HorrorSurvival => "Horror Survival",
                GameGenre.Western => "Western",
                GameGenre.Comedy => "Comedy",
                GameGenre.Mystery => "Mystery",
                GameGenre.Superhero => "Superhero",
                GameGenre.Space => "Space",
                GameGenre.PostApocalyptic => "Post-Apocalyptic",
                GameGenre.Zombie => "Zombie",
                GameGenre.Pirate => "Pirate",
                GameGenre.War => "War",
                GameGenre.Medieval => "Medieval",
                GameGenre.SportsSimulation => "Sports Simulation",
                GameGenre.VirtualReality => "Virtual Reality",
                GameGenre.AugmentedReality => "Augmented Reality",
                GameGenre.Social => "Social",
                GameGenre.BattleRoyale => "Battle Royale",
                GameGenre.Art => "Art",
                GameGenre.Exploration => "Exploration",
                GameGenre.Construction => "Construction",
                GameGenre.Trading => "Trading",
                GameGenre.LifeSimulation => "Life Simulation",
                _ => "Unknown",
            };
        }
    }
}