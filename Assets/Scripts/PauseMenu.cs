using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        bool destory = false;
        GameData saveGame = SaveGameData.LoadData();

        if (!SceneManager.GetActiveScene().name.Equals(saveGame.level))
        {
            destory = true;
            DontDestroyOnLoad(this);
                    SceneManager.LoadScene(saveGame.level);
        }



        while (!SceneManager.GetActiveScene().name.Equals(saveGame.level))
        {
            new WaitForSecondsRealtime(.5f);
            yield return null;
        }
        //GameObject[] newSceneObj = SceneManager.GetSceneByName(saveGame.level).GetRootGameObjects();

        PlayerController2D player = GameObject.Find("BurgerMan").GetComponent<PlayerController2D>();

        player.maxHealth = saveGame.maxHealth;
        player.currentHealth = saveGame.currentHealth;
        player.currentLives = saveGame.currentLives;
        PlayerController2D.livesValue = saveGame.currentLives;
        player.moveSpeed = saveGame.moveSpeed;
        player.jumpForce = saveGame.jumpForce;
        player.transform.position = new Vector3(saveGame.playerPosition[0], saveGame.playerPosition[1], saveGame.playerPosition[2]);

        if (saveGame.level.Equals("Level1"))
        {
            GameObject mouse = GameObject.Find("Mouse");
            if(mouse == null)
            {
                // create mouse
            }
            else
            {
                mouse.transform.position = new Vector3(saveGame.mousePosition[0], saveGame.mousePosition[1], saveGame.mousePosition[2]);
            }

            GameObject enemy = GameObject.Find("Enemy");
            GameObject enemyClone = GameObject.Find("Enemy(Clone)");
            if(enemyClone != null) { enemy = enemyClone; }
            if(enemy == null)
            {
                // create enemy 
                //try
                //{
                //    Debug.Log(Application.dataPath + "/Prefabs/Enemy.prefab");
                // //   Object enemyPrefab = Resources.Load(Application.dataPath + "/Prefabs/Enemy.prefab");
                //    //Assets / Prefabs / Enemy.prefab
                //    //Instantiate(enemyPrefab, new Vector3(saveGame.enemyPosistion[0], saveGame.enemyPosistion[1], saveGame.enemyPosistion[2]), Quaternion.identity);
                //}
                //catch
                //{
                //    Debug.Log("Error loading enemy asset");
                //}
                string enemyPrefabPath = "Prefabs/Enemy";
                Object enemyPrefab = Resources.Load(enemyPrefabPath);
                if(enemyPrefab == null)
                {
                    throw new FileNotFoundException(enemyPrefabPath);
                }
                else
                {
                    GameObject enemyObj = (GameObject) Instantiate(enemyPrefab, new Vector3(saveGame.enemyPosistion[0], saveGame.enemyPosistion[1], saveGame.enemyPosistion[2]), Quaternion.identity);
                    enemyObj.transform.localScale = new Vector3(saveGame.enemyScale[0], saveGame.enemyScale[1], saveGame.enemyScale[2]);
                }


            }
            else
            {
                enemy.transform.position = new Vector3(saveGame.enemyPosistion[0], saveGame.enemyPosistion[1], saveGame.enemyPosistion[2]);
            }
        }
        else if (saveGame.level.Equals("Level2"))
        {

        }

        ResumeGame();
        if (destory)
        {
            Destroy(this);
        }
        
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(4);
        //Debug.Log(Application.dataPath + "/Prefabs/Enemy.prefab");
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
