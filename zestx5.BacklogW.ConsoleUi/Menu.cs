using Spectre.Console;
using zestx5.BacklogW.Domain.Entities;
using zestx5.BacklogW.Infrastructure.Repositories;

namespace zestx5.BacklogW.ConsoleUi
{
    internal static class Menu
    {
        private const string allGames = "List all games";
        private const string addGame = "Add a game";
        private const string exit = "Exit";
        private static readonly InMemoryRepository _db = new();

        public static void DrawMainMenu()
        {
            AnsiConsole.Clear();

            var mainMenu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select an [red]option[/]:")
            .PageSize(10)
            .AddChoices(
                new[] { allGames, addGame, exit }
                )
            );

            switch (mainMenu)
            {
                case "List all games":
                    DrawShowAll();
                    break;
                case "Add a game":
                    DrawCreateGameMenu();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }

        }

        private static void DrawCreateGameMenu()
        {
            var title = AnsiConsole.Ask<string>("Enter a game [red]title:[/]");
            var genres = DrawGenreSelector();
            var status = DrawStatusSelector();
            var notes = AnsiConsole.Prompt(
                new TextPrompt<string>("[grey][[Optional]][/] [green]Enter notes:[/]")
                .AllowEmpty());

            var genreList = new List<GameGenre>();
            foreach (var genre in genres)
            {
                genreList.Add((GameGenre)Enum.Parse(typeof(GameGenre), genre));
            }

            _db.Add(new Game(title, (GameStatus)Enum.Parse(typeof(GameStatus), status), genreList, notes));
        }

        private static string DrawStatusSelector()
        {
            AnsiConsole.Clear();
            var statusList = Enum.GetNames(typeof(GameStatus));
            var status = AnsiConsole.Prompt(
            new SelectionPrompt<string>().PageSize(10)
                                              .Title("Genres: ")
                                              .MoreChoicesText("[grey](Move up and down to reveal more genres)[/]")
                                              .AddChoices(statusList));
            return status;
        }

        private static IEnumerable<string> DrawGenreSelector()
        {
            AnsiConsole.Clear();
            var genreList = Enum.GetNames(typeof(GameGenre));
            var selectedGenres = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>().PageSize(10)
                                              .Title("Genres: ")
                                              .MoreChoicesText("[grey](Move up and down to reveal more genres)[/]")
                                              .InstructionsText("[grey](Press [blue]space[/] to toggle a genre, [green]enter[/] to accept)[/]")
                                              .AddChoices(genreList));
            return selectedGenres;
        }

        static void DrawShowAll()
        {
            var gamesNames = _db.GetAll().Select(g => g.Name);

            var game = AnsiConsole.Prompt(
            new SelectionPrompt<Game>().Title("Select a [green]game[/]:")
                                       .PageSize(15)
                                       .MoreChoicesText("[grey](Move up and down to reveal more games)[/]")
                                       .AddChoices(_db.GetAll()));

            DrawShowDetails(game);
        }

        private static void DrawShowDetails(Game game)
        {
            AnsiConsole.Clear();
            var genres = string.Empty;
            game.Genre.ForEach(g => genres += g.GetLabel() + ", ");
            genres = genres.Trim().Remove(genres.Length - 2, 1);

            var select = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select a [red]field[/] to edit:")
                .AddChoices(
                    new[]
                    {
                        $"Title: {game.Name}",
                        $"Status: {game.Status}",
                        $"Genres: {genres}",
                        $"Notes: {game.Notes}",
                        "Delete",
                        "Back"
                    }
                    ));

            var selectSub = select.Contains(':') ? select[..select.IndexOf(':')] : select;
            ParseSelection(selectSub, game);
        }

        private static void ParseSelection(string select, Game game)
        {
            switch (select)
            {
                case "Title":
                    DrawEditTitle(game);
                    break;
                case "Status":
                    DrawEditStatus(game);
                    break;
                case "Notes":
                    DrawEditNotes(game);
                    break;
                case "Genres":
                    DrawEditGenres(game);
                    break;
                case "Delete":
                    _db.Remove(game);
                    break;
                case "Back":
                    return;
            };
        }

        private static void DrawEditGenres(Game game)
        {
            // Old genres not persisted
            var genreListNonParsed = DrawGenreSelector();
            var genreList = new List<GameGenre>();
            foreach (var genre in genreListNonParsed)
            {
                genreList.Add((GameGenre)Enum.Parse(typeof(GameGenre), genre));
            }
            game.Genre = genreList;
            DrawShowDetails(game);
        }

        private static void DrawEditNotes(Game game)
        {
            var notes = AnsiConsole.Prompt(
                new TextPrompt<string>("[grey][[Optional]][/] [green]Enter notes:[/]")
                .AllowEmpty());
            game.Notes = notes;
            DrawShowDetails(game);
        }

        private static void DrawEditStatus(Game game)
        {
            var status = DrawStatusSelector();
            game.Status = (GameStatus)Enum.Parse(typeof(GameStatus), status);
            DrawShowDetails(game);
        }

        private static void DrawEditTitle(Game game)
        {
            var title = AnsiConsole.Ask<string>($"Enter new title(current [red]{game.Name}[/]): ");
            game.Name = title;
            DrawShowDetails(game);
        }
    }
}
