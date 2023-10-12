namespace zestx5.BacklogW.Domain.Entities
{
    public class Game
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public GameStatus Status { get; set; }
        public List<GameGenre> Genre { get; set; }

        public Game(string name, GameStatus status, List<GameGenre> genre, string notes = "")
        {
            Name = name;
            Notes = notes;
            Status = status;
            Genre = genre;
        }

        public override string? ToString()
        {
            return $"{Name}";
        }
    }
}
