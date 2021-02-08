using Levels;
using SpriteTexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : AbstractMenu
    {
        private void Awake()
        {
            this.InitializeStates(
                new MenuState(0, "NewGame", this.StartNewGame),
                new MenuState(1, "Exit", this.ExitGame)
                );
            LevelManager.InitializeLevels(this.WinLevel, this.ReturnToMain);
        }


        private void StartNewGame()
        {
            this._newGameStarts = StartCoroutine(this.NewGameStarts());

        }

        private void WinLevel()
        {
            SceneManager.LoadScene(1);
        }

        private IEnumerator NewGameStarts()
        {
            this._phoneInvisibleMaker.SetTrigger("NewGameStarts");
            while (!this._phoneInvisibleMaker.GetCurrentAnimatorStateInfo(0).IsName("PhoneInvisible"))
                yield return null;
            this._introText.ActivateIntro();
            while (!Input.GetKeyDown(this._skipIntro))
                yield return null;

            StopCoroutine(this._newGameStarts);
            SceneManager.LoadScene(0);
            yield break;
        }

        private Coroutine _newGameStarts;

        [SerializeField] private KeyCode _skipIntro = KeyCode.Keypad5;
        [SerializeField] private IntroText _introText;
        [SerializeField] private Animator _phoneInvisibleMaker;
    }
}
