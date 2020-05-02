using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Tests
{
    public class MenuTests
    {
        [UnityTest]
        public IEnumerator MenuCanvasShouldNotBeNullOnLoad()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var mainMenuCanvas = GameObject.Find("Canvas");

            Assert.IsNotNull(mainMenuCanvas);
        }

        public IEnumerator MainMenuShouldNotBeNullOnLoad()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var mainMenu = GameObject.Find("MainMenu");

            Assert.IsNotNull(mainMenu);
        }

        [UnityTest]
        public IEnumerator NewGameButtonShouldNotBeNull()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var newGameButton = GameObject.Find("NewGameButton");

            Assert.IsNotNull(newGameButton);
        }

        [UnityTest]
        public IEnumerator NewGameButtonShouldLoadLevel1OnClick()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var eventSystem = EventSystem.current;
            var newGameButton = GameObject.Find("NewGameButton");
            ExecuteEvents.Execute(newGameButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);

            yield return null;
            var newScene = SceneManager.GetActiveScene().name;

            Assert.AreEqual("Level1", newScene);
        }

        [UnityTest]
        public IEnumerator OptionsButtonShouldNotBeNull()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var optionsButton = GameObject.Find("OptionsButton");

            Assert.IsNotNull(optionsButton);
        }

         [UnityTest]
        public IEnumerator OptionsButtonShouldLoadOptionsMenuOnClick()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var eventSystem = EventSystem.current;
            var newGameButton = GameObject.Find("OptionsButton");
            ExecuteEvents.Execute(newGameButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
            
            yield return null;
            var newScene = SceneManager.GetActiveScene().name;
            
            Assert.AreEqual("OptionsMenu", newScene);
        }

        [UnityTest]
        public IEnumerator QuitButtonShouldNotBeNull()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var quitButton = GameObject.Find("QuitButton");

            Assert.IsNotNull(quitButton);
        }

        [UnityTest]
        public IEnumerator LoadGameButtonShouldNotBeNull()
        {
            SceneManager.LoadScene("Menu");
            yield return null;
            var loadGameButton = GameObject.Find("LoadGameButton");

            Assert.IsNotNull(loadGameButton);
        }
    }
}