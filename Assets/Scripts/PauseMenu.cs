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
        if(gameData.level.Equals("Level1"))
        {
            gameData.AddMouse(GameObject.Find("Mouse"));
            gameData.AddEnemy(GameObject.Find("Enemy"));
            gameData.AddFallingObjs(new GameObject[3] { GameObject.Find("Tomato1"), GameObject.Find("Tomato2"), GameObject.Find("Tomato3") });
        } else if(gameData.level.Equals("Level2"))
        {
            gameData.AddTomatoSlices(new GameObject[6] { GameObject.Find("TomatoSlice1.1"), GameObject.Find("TomatoSlice1.2"), GameObject.Find("TomatoSlice1.3"), GameObject.Find("TomatoSlice2.1"), GameObject.Find("TomatoSlice2.2"), GameObject.Find("TomatoSlice2.3") });
            gameData.AddBurgerEnemies(new GameObject[6] { GameObject.Find("Enemy1"), GameObject.Find("Enemy2"), GameObject.Find("Enemy3"), GameObject.Find("Enemy4"), GameObject.Find("Enemy5"), GameObject.Find("Enemy6") });
            gameData.AddDroppingFloors(new GameObject[5] { GameObject.Find("dropFloor1"), GameObject.Find("dropFloor1 (1)"), GameObject.Find("dropFloor1 (2)"), GameObject.Find("dropFloor1 (3)"), GameObject.Find("dropFloor1 (4)"), });
        }

        SaveGameData.SaveData(gameData);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        DontDestroyOnLoad(this);

        GameData saveGame = SaveGameData.LoadData();
        SceneManager.LoadScene(saveGame.level);

        while (!SceneManager.GetActiveScene().name.Equals(saveGame.level))
        {
            Debug.Log("Active Scene: " + SceneManager.GetActiveScene().name);
            Debug.Log("Loading Scene: " + saveGame.level);
            new WaitForSecondsRealtime(.5f);
            yield return null;
        }
        GameObject[] newSceneObj = SceneManager.GetSceneByName(saveGame.level).GetRootGameObjects();

        PlayerController2D player = null;

        foreach (GameObject obj in newSceneObj)
        {
            if (obj.name.Equals("BurgerMan"))
            {
                player = obj.GetComponentInChildren<PlayerController2D>();
            }
        }

        player.maxHealth = saveGame.maxHealth;
        player.currentHealth = saveGame.currentHealth;
        player.currentLives = saveGame.currentLives;
        PlayerController2D.livesValue = saveGame.currentLives;
        player.moveSpeed = saveGame.moveSpeed;
        player.jumpForce = saveGame.jumpForce;
        player.transform.position = new Vector3(saveGame.playerPosition[0], saveGame.playerPosition[1], saveGame.playerPosition[2]);

        ResumeGame();
        Destroy(this);
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
