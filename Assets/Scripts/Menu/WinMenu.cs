using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class WinMenu : AbstractMenu
    {
        private void Awake()
        {
            this.InitializeStates(
                new MenuState(0, "Next", this.StartNextLevel), 
                new MenuState(1, "Main", this.ReturnToMain), 
                new MenuState(2, "Exit", this.ExitGame)
                );

        }

        private void StartNextLevel()
        {
            //TODO start next level
        }

        private void ReturnToMain()
        {

        }

    }
}
