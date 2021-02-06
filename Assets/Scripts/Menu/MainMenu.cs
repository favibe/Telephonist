using SpriteTexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text;
using UnityEngine;


namespace Menu
{
    public class MainMenu : AbstractMenu
    {
        private void Awake()
        {
            this.InitializeStates(
                new MenuState(0, "NewGame", this.StartNewGame),
                new MenuState(1, "Levels", this.ShowLevels),
                new MenuState(2, "Exit", this.ExitGame)
                );
        }


        public void StartNewGame()
        {
            //TODO animation of starting
        }

        public void ShowLevels()
        {
            //TODO maybe it's unnecessary
        }


    }
}
