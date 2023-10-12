using Spectre.Console;
using zestx5.BacklogW.Domain.Entities;
using zestx5.BacklogW.Infrastructure.Repositories;

namespace zestx5.BacklogW.ConsoleUi
{
    internal static class Menu
    {
        private static readonly InMemoryRepository _db = new();

        public static void DrawMainMenu()
        {
            AnsiConsole.Clear();

            var mainMenu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select an [red]option[/]:")
            .PageSize(10)
            .AddChoices(
                new[] { "List all", "Add a game", "Exit" }
                )
            );

            switch (mainMenu)
            {
                case "List all":
                    ShowAll();
                    break;
                case "Add a game":
                    DrawCreateGameMenu();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }

        }

        static void DrawCreateGameMenu()
        {
            var title = AnsiConsole.Ask<string>("Enter game [red]title:[/]");
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

        static string DrawStatusSelector()
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

        static IEnumerable<string> DrawGenreSelector()
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

        static void ShowAll()
        {
            var gamesNames = _db.GetAll().Select(g => g.Name);

            var game = AnsiConsole.Prompt(
            new SelectionPrompt<Game>().Title("Select a [green]game[/]:")
                                       .PageSize(15)
                                       .MoreChoicesText("[grey](Move up and down to reveal more games)[/]")
                                       .AddChoices(_db.GetAll()));

            ShowDetails(game);
        }

        static void ShowDetails(Game game)
        {
            AnsiConsole.Clear();
            var genres = string.Empty;
            game.Genre.ForEach(g => genres += g.GetLabel() + ", ");
            genres = genres.Trim().Remove(genres.Length - 2, 1);

            var select = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select the [red]field[/] to edit:")
            .AddChoices(
            new[]
            {
                $"Title: {game.Name}",
                $"Status: {game.Status}",
                $"Genres: {genres}",
                $"Notes: {game.Notes}"
            }
            ));
        }
    }
}
