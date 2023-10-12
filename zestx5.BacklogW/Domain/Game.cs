using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zestx5.BacklogW.Domain
{
    public class Game
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public Game(string name, string notes)
        {
            Name = name;
            Notes = notes;
        }
    }
}
