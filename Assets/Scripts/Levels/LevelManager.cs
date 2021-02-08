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

                    0f,
                    new Thesis("Okay, let's practice!", MessageType.Incoming, 5f),
                    new Thesis("First of all, type 'abc'. Use Num2 key.", MessageType.Incoming, 3f),
                    new Thesis("If you were incorrect, use Num0 to delete last symbol.", MessageType.Incoming, 5f),
                    new Thesis("abc", MessageType.Outgoing),
                    new Thesis("Good, it's not so difficult!", MessageType.Incoming, 3f),
                    new Thesis("Now, type 'def', like 'define' but a little shorter.", MessageType.Incoming, 5f),
                    new Thesis("def", MessageType.Outgoing),
                    new Thesis("Okay, I supose you understood how it works.", MessageType.Incoming, 4f),
                    new Thesis("Finaly type me 'ghi jkl mno pqrs tuvw xyz'", MessageType.Incoming, 3f),
                    new Thesis("ghi jkl mno pqrs tuvw xyz", MessageType.Outgoing),
                    new Thesis("I think, authors of TextMe couldn't do it better!", MessageType.Incoming, 5f),
                    new Thesis("Now, it's time to text some real messages", MessageType.Incoming, 4f),
                    new Thesis("Good luck!", MessageType.Incoming, 5f)
                    ),
                new Level(
                    420f,
                    new Thesis("You know what the funniest thing about Europe is?", MessageType.Incoming, 1f),
                    new Thesis("What?", MessageType.Outgoing),
                    new Thesis("It's the little differences.", MessageType.Incoming, 1f),
                    new Thesis("I mean, they got the same shit over there that we got here, but it's just...", MessageType.Incoming, 5f),
                    new Thesis("It's just, there it's a little different", MessageType.Incoming, 3f),
                    new Thesis("Example?", MessageType.Outgoing),
                    new Thesis("All right. Well, you can walk into a movie theater in Amsterdam and buy a beer.", MessageType.Incoming, 5f),
                    new Thesis("And I don't mean just like in no paper cup; I'm talking about a glass of beer.", MessageType.Incoming, 5f),
                    new Thesis("And in Paris, you can buy a beer at McDonald's.", MessageType.Incoming, 1f),
                    new Thesis("And you know what they call a Quarter Pounder with Cheese in Paris?", MessageType.Incoming, 3f),
                    new Thesis("They don't call it a Quarter Pounder with Cheese?", MessageType.Outgoing),
                    new Thesis("Nah, man, they got the metric system.", MessageType.Incoming, 4f),
                    new Thesis("They wouldn't know the fuck a Quarter Pounder is.", MessageType.Incoming, 3f),
                    new Thesis("What do they call it?", MessageType.Outgoing),
                    new Thesis("They call it a 'Royale with Cheese.'", MessageType.Incoming, 3f),
                    new Thesis("'Royale with Cheese.'", MessageType.Outgoing),
                    new Thesis("That's right.", MessageType.Incoming, 2f),
                    new Thesis("What do they call a Big Mac?", MessageType.Outgoing),
                    new Thesis("A Big Mac's a Big Mac, but they call it 'Le Big Mac.'", MessageType.Incoming, 3f),
                    new Thesis("'Le Big Mac.' What do they call a Whopper?", MessageType.Outgoing),
                    new Thesis("I don't know, I didn't go in a Burger King.", MessageType.Incoming, 3f),
                    new Thesis("You know what they put on French fries in Holland instead of ketchup?", MessageType.Incoming, 3f),
                    new Thesis("What?", MessageType.Outgoing),
                    new Thesis("Mayonnaise.", MessageType.Incoming, 2f),
                    new Thesis("Goddamn.", MessageType.Outgoing),
                    new Thesis("I seen them do it, man, they fucking drown them in that shit.", MessageType.Incoming, 3f),
                    new Thesis("Yuck.", MessageType.Outgoing)
                    ),
				new Level(
                    300f,
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
                    ),
                new Level(
                    420f,
                    new Thesis("It's not what you did, son, that angers me so.", MessageType.Incoming, 5f),
                    new Thesis("It's who you did it to.", MessageType.Incoming, 3f),
                    new Thesis("Who? That fucking nobody?", MessageType.Outgoing),
                    new Thesis("That fuckin' nobody is John Wick. ", MessageType.Incoming, 5f),
                    new Thesis("He was once an associate of ours. We called him…Baba Yaga.", MessageType.Incoming, 5f),
                    new Thesis("The Boogeyman?", MessageType.Outgoing),
                    new Thesis("Well, John wasn't exactly 'The Boogeyman'.", MessageType.Incoming, 5f),
                    new Thesis("He was the one you sent to kill the fuckin' Boogeyman.", MessageType.Incoming, 5f),
                    new Thesis("...Oh.", MessageType.Outgoing),
                    new Thesis("John, is a man of focus. Commitment. Sheer will.", MessageType.Incoming, 5f),
                    new Thesis("Something you know very little about. I once saw him kill three men in a bar...", MessageType.Incoming, 5f),
                    new Thesis("...with a pencil. With a fuckin' pencil.", MessageType.Incoming, 3f),
                    new Thesis("Suddenly one day he asked to leave. It was over a woman, of course.", MessageType.Incoming, 5f),
                    new Thesis("So I made a deal with him. I gave him an impossible task.", MessageType.Incoming, 5f),
                    new Thesis("A job no one could have pulled off.", MessageType.Incoming, 3f),
                    new Thesis("The bodies he buried that day laid the foundation of what we are now.", MessageType.Incoming, 5f),
                    new Thesis("And then, my son, a few days after his wife died...", MessageType.Incoming, 5f),
                    new Thesis("...you steal his car, and kill his fuckin' dog.", MessageType.Incoming, 5f),
                    new Thesis("Father, I can make this right!", MessageType.Outgoing),
                    new Thesis("Oh? How do you plan that?", MessageType.Incoming, 5f),
                    new Thesis("By finishing what I started.", MessageType.Outgoing),
                    new Thesis("What the... did he hear a fucking word I said?", MessageType.Incoming, 5f),
                    new Thesis("Dad, I can do this! Please!", MessageType.Outgoing),
                    new Thesis("Iosef. Iosef! Listen.", MessageType.Incoming, 5f),
                    new Thesis("John will come for you, and I will do nothing because you can do nothing.", MessageType.Incoming, 5f),
                    new Thesis("So get the fuck out of my sight!", MessageType.Incoming, 5f)
                    ),
                new Level(
                    0f,
                    new Thesis("Wow, amazing!", MessageType.Incoming, 3f),
                    new Thesis("If you see this message, you are so cool!", MessageType.Incoming, 3f),
                    new Thesis("We hope you feel good playing TextMe.", MessageType.Incoming, 5f),
                    new Thesis("Now rate it please. Type a number from 1 to 10.", MessageType.Incoming, 3f),
                    new Thesis("10", MessageType.Incoming),
                    new Thesis("Yeah, thank you so much.", MessageType.Incoming, 7f),
                    new Thesis("(Yeah, we kmow, you're unable to print another).", MessageType.Incoming, 5f),
                    new Thesis("Anyway, we are so glad to see anyone finished our game.", MessageType.Incoming, 5f),
                    new Thesis("Have fun!", MessageType.Incoming, 5f)
                    )
                /*

                Viggo Tarasov: 
Iosef Tarasov: 
Viggo Tarasov: 
Iosef Tarasov: ""?
Viggo Tarasov:  
Iosef Tarasov: 
[In the background, John takes a sledgehammer to his basement, and as Viggo talks, he unearths his hitman equipment that he had buried in concrete]

Viggo Tarasov:  …     … 
Iosef Tarasov: 
Viggo Tarasov: 
Iosef Tarasov: 
Viggo Tarasov: [turns to his advisor, Avi] 
Iosef Tarsov: [in Russian] 
[irritated yet scared, Viggo pulls his son close and talks in his ear]
Viggo Tarasov:   









                 */
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
