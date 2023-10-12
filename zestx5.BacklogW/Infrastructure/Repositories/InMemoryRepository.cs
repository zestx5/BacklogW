using System.Linq.Expressions;
using zestx5.BacklogW.Domain.Entities;
using zestx5.BacklogW.Domain.Repositories;

namespace zestx5.BacklogW.Infrastructure.Repositories
{
    public class InMemoryRepository : IRepository<Game>
    {
        private List<Game> _games = new();

        public InMemoryRepository()
        {
            _games = Utility.GenerateStubData();
        }

        public void Add(Game entity)
        {
            _games.Add(entity);
        }

        public void AddRange(IEnumerable<Game> entities)
        {
            _games.AddRange(entities);
        }

        public IEnumerable<Game> Find(Expression<Func<Game, bool>> predicate)
        {
            return _games != null ? _games.Where(predicate.Compile()) : Enumerable.Empty<Game>();
        }

        public IEnumerable<Game> GetAll()
        {
            return _games;
        }

        public Game GetById(Guid id)
        {
            return _games.Where(g => g.Guid == id).First();
        }

        public void Remove(Game entity)
        {
            _games.Remove(entity);
        }

        public void Update(Game entity)
        {
            foreach (var g in _games)
            {
                if (g.Guid == entity.Guid)
                {
                    g.Notes = entity.Notes;
                    g.Status = entity.Status;
                    g.Genre= entity.Genre;
                    g.Name = entity.Name;

                    return;
                }
            }
        }

    }
}
