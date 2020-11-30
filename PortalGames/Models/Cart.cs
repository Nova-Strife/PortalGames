using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames.Models
{
    public class Cart : ICollection<Game>
    {
        public List<Game> _games = new List<Game>();
        public Game this[int index]
        {
            get => _games[index];
            set => _games[index] = value;
        }

        public int Count => ((ICollection<Game>)_games).Count;

        public bool IsReadOnly => ((ICollection<Game>)_games).IsReadOnly;

        public void Add(Game item)
        {
            ((ICollection<Game>)_games).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Game>)_games).Clear();
        }

        public bool Contains(Game item)
        {
            return ((ICollection<Game>)_games).Contains(item);
        }

        public void CopyTo(Game[] array, int arrayIndex)
        {
            ((ICollection<Game>)_games).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Game> GetEnumerator()
        {
            return ((IEnumerable<Game>)_games).GetEnumerator();
        }

        public bool Remove(Game item)
        {
            return ((ICollection<Game>)_games).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_games).GetEnumerator();
        }
    }
}
