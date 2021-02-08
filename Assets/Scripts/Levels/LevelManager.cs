using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messaging;

namespace Levels
{
    public static class LevelManager
    {
        public static void InitializeLevels(Action onLevelEnded, Action finalLevelEnded)
        {
            _levels = new List<Level>()
            {
                new Level(
                    0f, onLevelEnded,
                    new Thesis("Okay, let's practice!", MessageType.Incoming, 1f),
                    new Thesis("First of all, type 'abc'. Use Num2 key.", MessageType.Incoming, 1f),
                    new Thesis("If you were incorrect, use Num0 to delete last symbol.", MessageType.Incoming, 1f),
                    new Thesis("abc", MessageType.Outgoing),
                    new Thesis("Good, it's not so difficult!", MessageType.Incoming, 1f),
                    new Thesis("Now, type 'def', like 'define' but a little shorter.", MessageType.Incoming, 1f),
                    new Thesis("def", MessageType.Outgoing),
                    new Thesis("Okay, I supose you understood how it works.", MessageType.Incoming, 1f)
                    //new Thesis("Finaly type me 'ghi jkl mno pqrs tuvw xyz'", MessageType.Incoming, 1f),
                    //new Thesis("ghi jkl mno pqrs tuvw xyz", MessageType.Outgoing),
                    //new Thesis("I think, authors of TextMe couldn't do it better!", MessageType.Incoming, 2f),
                    //new Thesis("Now, it's time to text some real messages", MessageType.Incoming, 2f),
                    //new Thesis("Good luck!", MessageType.Incoming, 5f)
                    )
            };
            _index = 0;

            _finalLevelEnded = finalLevelEnded;
        }

        public static Level Current => _levels[_index];
        public static void MoveNext()
        {
            _index++;
            if(_index >= _levels.Count)
            {
                _finalLevelEnded?.Invoke();
            }

        }

        private static Action _finalLevelEnded;
        private static int _index; 
        private static List<Level> _levels;
    }
}
