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
                new[] { "List all", "Exit" }
                )
            );

            switch (mainMenu)
            {
                case "List all":
                    ShowAll();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }

        }

        static void ShowAll()
        {
            var gamesNames = _db.GetAll().Select(g => g.Name);

            var game = AnsiConsole.Prompt(
            new SelectionPrompt<Game>()
        .Title("Select a [green]game[/]:")
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
                new[]{
                    $"Title: {game.Name}",
                    $"Status: {game.Status}",
                    $"Genres: {genres}",
                    $"Notes: {game.Notes}"
                    }
                ));
        }
    }
}
