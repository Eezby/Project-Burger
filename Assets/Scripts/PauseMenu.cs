using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void MainMenu() {
        SceneManager.LoadScene(1);
        ResumeGame();
    }

    public void SaveGame()
    {
        GameData gameData = new GameData(GameObject.Find("BurgerMan").GetComponentInChildren<PlayerController2D>());
        gameData.AddMouse(GameObject.Find("Mouse"));
        gameData.AddEnemy(GameObject.Find("Enemy"));
        gameData.AddFallingObjs(new GameObject[3] { GameObject.Find("Tomato1"), GameObject.Find("Tomato2"), GameObject.Find("Tomato3") });
        gameData.AddTomatoSlices(new GameObject[6] { GameObject.Find("TomatoSlice1.1"), GameObject.Find("TomatoSlice1.2"), GameObject.Find("TomatoSlice1.3"), GameObject.Find("TomatoSlice2.1"), GameObject.Find("TomatoSlice2.2"), GameObject.Find("TomatoSlice2.3") });

        SaveGameData.SaveData(gameData);
    }

    public void LoadGame()
    {

    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
