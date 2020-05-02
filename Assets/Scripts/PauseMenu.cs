using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SceneManager.GetActiveScene().Equals("Menu"))
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
        SaveGame("/save.dat");
    }

    public void SaveGame(string saveName)
    {
        GameData gameData = new GameData(GameObject.Find("BurgerMan").GetComponentInChildren<PlayerController2D>());
        if(gameData.level.Equals("Level1"))
        {
            gameData.AddMouse(GameObject.Find("Mouse"));
            gameData.AddEnemy(GameObject.Find("Enemy"));
            gameData.AddFallingObjs(new GameObject[3] { GameObject.Find("Tomato1"), GameObject.Find("Tomato2"), GameObject.Find("Tomato3") });
            gameData.AddDroppingFloors(new GameObject[5] { GameObject.Find("dropFloor1"), GameObject.Find("dropFloor2"), GameObject.Find("dropFloor3"), GameObject.Find("dropFloor4"), GameObject.Find("dropFloor5") });
        } else if(gameData.level.Equals("Level2"))
        {
            gameData.AddTomatoSlices1(new GameObject[3] { GameObject.Find("TomatoSlice1.1"), GameObject.Find("TomatoSlice1.2"), GameObject.Find("TomatoSlice1.3")});
            gameData.AddTomatoSlices2(new GameObject[3] { GameObject.Find("TomatoSlice2.1"), GameObject.Find("TomatoSlice2.2"), GameObject.Find("TomatoSlice2.3") });
            gameData.AddBurgerEnemies(new GameObject[6] { GameObject.Find("Enemy1"), GameObject.Find("Enemy2"), GameObject.Find("Enemy3"), GameObject.Find("Enemy4"), GameObject.Find("Enemy5"), GameObject.Find("Enemy6") });
            gameData.AddDroppingFloors(new GameObject[5] { GameObject.Find("dropFloor1"), GameObject.Find("dropFloor2"), GameObject.Find("dropFloor3"), GameObject.Find("dropFloor4"), GameObject.Find("dropFloor5"), });
        }

        SaveGameData.SaveData(gameData, saveName);
    }

    public void LoadGame()
    {
        LoadGame("/save.dat");
    }

    public void LoadGame(string saveName)
    {
        if (!pauseMenuUI.activeSelf) { PauseGame(); }
        StartCoroutine(LoadSceneRoutine(saveName));
    }

    private IEnumerator LoadSceneRoutine(string saveName)
    {

        bool destory = false;
        GameData saveGame = SaveGameData.LoadData(saveName);
        
        if(saveGame == null) { yield break; }

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

            SpawnSaveObj("Mouse", "Mouse", "", saveGame.mousePosition, saveGame.mouseScale);
            SpawnSaveObj("Enemy", "Enemy", "", saveGame.enemyPosistion, saveGame.enemyScale);
            SpawnSaveObj("Tomato", "FallingObjects", saveGame.fallingObjPosition, saveGame.fallingObjScale);
            SpawnSaveObj("dropFloor", "Floor", saveGame.droppingFloorPos, saveGame.droppingFloorScale);

        }
        else if (saveGame.level.Equals("Level2"))
        {
            SpawnSaveObj("TomatoSlice1.", "TomatoSlices", saveGame.tomatoSlicePos1, saveGame.tomatoSliceScale1);
            SpawnSaveObj("TomatoSlice2.", "TomatoSlices", saveGame.tomatoSlicePos2, saveGame.tomatoSliceScale2);
            SpawnSaveObj("Enemy", "BurgerEnemies", saveGame.burgerEnemiesPos, saveGame.burgerEnemiesScale);
            SpawnSaveObj("dropFloor", "Dropping floors", saveGame.droppingFloorPos, saveGame.droppingFloorScale);
        }

        ResumeGame();
        if (destory)
        {
            Destroy(this);
        }
        
    }

    private void SpawnSaveObj(string objName, string parent, float[,] position, float[,] scale)
    {
        string objPrefabName = objName;
        if (objName.Equals("TomatoSlice1.")) { objPrefabName = "TomatoSlice"; }
        if (objName.Equals("TomatoSlice2.")) { objPrefabName = "TomatoSlice"; }

        for (int i = 0; i < (int)Mathf.Sqrt(position.Length); i++)
        {
            //float[] pos = Enumerable.Range(0, position.GetLength(1)).Select(x => position[i, x]).ToArray();
            //float[] scaless = Enumerable.Range(0, scale.GetLength(1)).Select(x => scale[i, x]).ToArray();
            SpawnSaveObj((objName + (i + 1)), objName, parent, Enumerable.Range(0, position.GetLength(1)).Select(x => position[i, x]).ToArray(), Enumerable.Range(0, scale.GetLength(1)).Select(x => scale[i, x]).ToArray());
        }
    }

    private void SpawnSaveObj(string objName, string objPrefabName, string parent, float[] position, float[] scale)
    {
        GameObject obj = GameObject.Find(objName);
        //GameObject objCopy = GameObject.Find(objName + "(Copy)");
        //if (objCopy != null) { obj = objCopy; }

        if (position != null)
        {
            if (obj == null)
            {
                string objPrefabPath = "Prefabs/" + objPrefabName;
                Object objPrefab = Resources.Load(objPrefabPath);
                if (objPrefab == null)
                {
                    throw new FileNotFoundException(objPrefabPath);
                }
                else
                {
                    GameObject objGameObject = (GameObject)Instantiate(objPrefab, new Vector3(position[0], position[1], position[2]), Quaternion.identity);
                    objGameObject.name = objName;
                    objGameObject.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
                    if (objName.Equals("Mouse")) { objGameObject.GetComponentInChildren<DamagePlayer>().player = GameObject.Find("BurgerMan"); }
                    if (objPrefabName.Equals("Tomato")) { objGameObject.GetComponentInChildren<ObjectFall>().player = GameObject.Find("BurgerMan"); }
                    if(parent.Length != 0)
                    {
                        GameObject parentObj = GameObject.Find(parent);
                        if(parentObj != null)
                        {
                            objGameObject.transform.parent = parentObj.transform;
                        }
                        else
                        {
                            Debug.Log("Requested Parent Not Found for child " + objName);
                        }
                    }
                }
            }
            else
            {
                obj.transform.position = new Vector3(position[0], position[1], position[2]);
                obj.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
            }

        }
        else
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }

    public void OptionsMenu()
    {
        SaveGame("/temp.dat");
        SceneManager.LoadScene(4);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        //if (Application.isEditor)
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
        //else
        //{
        //    Application.Quit();
        //}
    }
}
