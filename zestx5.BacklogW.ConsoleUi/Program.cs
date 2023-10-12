using ConsoleTools;
using zestx5.BacklogW.Domain.Entities;
using zestx5.BacklogW.Infrastructure.Repositories;

var db = new InMemoryRepository();



var mainMenu = new ConsoleMenu(args, level: 0)
    .Add("List all", ShowAll)
    .Add("Exit", () => Environment.Exit(0));

mainMenu.Configure(cfg =>
{
    cfg.Title = "BacklogW";
});
mainMenu.Show();

void ShowAll()
{
    var subMenu = new ConsoleMenu(args, level: 1)
          .Configure(cfg =>
          {
              cfg.WriteHeaderAction = () => Console.WriteLine("Pick a game");
          });

    var gamesList = db.GetAll();

    foreach (var item in gamesList)
    {
        subMenu.Add(item.Name, () =>
        {
            ShowDetails(item);
        });
    }
    subMenu.Add("Back", subMenu.CloseMenu);
    subMenu.Show();
}

void ShowDetails(Game game)
{
    var gameMenu = new ConsoleMenu(args, level: 2);
    gameMenu.Configure(cfg => { cfg.WriteHeaderAction = () => Console.WriteLine(game.Name + "\nSelect to edit:"); });
    gameMenu.Add("Status: " + game.Status.ToString(), () => Console.Write(""));

    var genres = string.Empty;
    game.Genre.ForEach(g => genres += g.GetLabel() + ", ");
    genres = genres.TrimEnd().Remove(genres.Length - 2, 1);
    gameMenu.Add($"Genres: {genres}", () => Console.WriteLine(""));

    var notes = game.Notes == "" ? "<empty>" : game.Notes;
    gameMenu.Add($"Notes: {notes}", () => Console.Write(""));

    gameMenu.Add("Back", gameMenu.CloseMenu);
    gameMenu.Show();
}