using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class LoseMenu : AbstractMenu
    {
        private void Awake()
        {
            this.InitializeStates(
                new MenuState(0, "Retry", this.RetryLevel),
                new MenuState(1, "Main", this.ReturnToMain),
                new MenuState(2, "Exit", this.ExitGame)
                );
        }

        private void RetryLevel()
        {
            SceneManager.LoadScene(1);
        }
    }
}
