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
                    300,
                    new Thesis("I'm sorry, did I break your concentration?", MessageType.Incoming, 4f),
                    new Thesis("I didn't mean to do that.", MessageType.Incoming, 2f),
                    new Thesis("Please, continue.", MessageType.Incoming, 2f),
                    new Thesis("You were saying something about best intentions.", MessageType.Incoming, 4f),
                    new Thesis("What's the matter?", MessageType.Incoming, 2f),
                    new Thesis("Oh, you were finished!", MessageType.Incoming, 2f),
                    new Thesis("Well, allow me to retort.", MessageType.Incoming, 2f),
                    new Thesis("What does Marsellus Wallace look like?", MessageType.Incoming, 2f),
                    new Thesis("What?", MessageType.Outgoing, 2f),
                    new Thesis("What country are you from?", MessageType.Incoming, 2f),
                    new Thesis("What? What?!", MessageType.Outgoing, 2f),
                    new Thesis("\"What\" ain't no country I've ever heard of.", MessageType.Incoming, 2f),
                    new Thesis("They speak English in What?", MessageType.Incoming, 2f),
                    new Thesis("What?", MessageType.Outgoing, 2f),
                    new Thesis("English, motherfucker, do you speak it?", MessageType.Incoming, 4f),
                    new Thesis("Yes. Yes!", MessageType.Outgoing, 2f),

                    new Thesis("Then you know what I'm sayin'!", MessageType.Incoming, 2f),
                    new Thesis("Yes!", MessageType.Outgoing, 2f),
                    new Thesis("Describe what Marsellus Wallace looks like!", MessageType.Incoming, 2f),
                    new Thesis("What?", MessageType.Outgoing, 2f),
                    new Thesis("Say 'what' again.", MessageType.Incoming, 2f),
                    new Thesis("Say 'what' again, I dare you", MessageType.Incoming, 2f),
                    new Thesis("I double dare you motherfucker", MessageType.Incoming, 2f),
                    new Thesis("say what one more Goddamn time!", MessageType.Incoming, 2f)
                    )
            };

            for (int i = 0; i < _levels.Count - 1; i++)
            {
                _levels[i].OnSequenceEnded += onLevelEnded;
            }

            _levels[_levels.Count - 1].OnSequenceEnded += finalLevelEnded;
            _index = 0;

            _finalLevelEnded = finalLevelEnded;
        }

        public static int Index => _index;
        public static Level Current => _levels[_index];
        public static void MoveNext()
        {
            _index++;
        }

        private static Action _finalLevelEnded;
        private static int _index;
        private static List<Level> _levels;
    }
}
