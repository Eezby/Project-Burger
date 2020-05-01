using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public int level;

    public int currentHealth;
    public int maxHealth;
    public int currentLives;

    public float moveSpeed;
    public float jumpForce;
    public float[] playerPosition;

    // level 1
    public float[] mousePosition;
    public float[,] fallingObjPosition;
    public float[] enemyPosistion;

    // level 2
    public float[,] tomatoSlicePos;
    public float[,] burgerEnemiesPos;
    public float[,] droppingFloorPos;

    public GameData(PlayerController2D burgerMan)
    {
        playerPosition = new float[3];
        playerPosition[0] = burgerMan.transform.position.x;
        playerPosition[1] = burgerMan.transform.position.y;
        playerPosition[2] = burgerMan.transform.position.z;

        currentHealth = burgerMan.currentHealth;
        maxHealth = burgerMan.maxHealth;
        currentLives = burgerMan.currentLives;

        moveSpeed = burgerMan.moveSpeed;
        jumpForce = burgerMan.jumpForce;

        level = SceneManager.GetActiveScene().buildIndex;
    }

    public void AddMouse(GameObject mouse)
    {
        mousePosition = new float[3];
        mousePosition[0] = mouse.transform.position.x;
        mousePosition[1] = mouse.transform.position.y;
        mousePosition[2] = mouse.transform.position.z;
    }

    public void AddEnemy(GameObject enemy)
    {
        enemyPosistion = new float[3];
        enemyPosistion[0] = enemy.transform.position.x;
        enemyPosistion[1] = enemy.transform.position.y;
        enemyPosistion[2] = enemy.transform.position.z;
    }

    public void AddFallingObjs(GameObject[] tomatos)
    {
        int expectedNum = 3;
        if(tomatos.Length != expectedNum)
        {
            return;
        }
        fallingObjPosition = new float[expectedNum, 3];
        for(int i = 0; i < tomatos.Length; i++)
        {
            fallingObjPosition[i, 0] = tomatos[i].transform.position.x;
            fallingObjPosition[i, 1] = tomatos[i].transform.position.y;
            fallingObjPosition[i, 2] = tomatos[i].transform.position.z;
        }
    }

    public void AddTomatoSlices(GameObject[] tomatos)
    {
        int expectedNum = 6;
        if (tomatos.Length != expectedNum)
        {
            return;
        }
        tomatoSlicePos = new float[expectedNum, 3];
        for (int i = 0; i < tomatos.Length; i++)
        {
            tomatoSlicePos[i, 0] = tomatos[i].transform.position.x;
            tomatoSlicePos[i, 1] = tomatos[i].transform.position.y;
            tomatoSlicePos[i, 2] = tomatos[i].transform.position.z;
        }
    }

    public void AddBurgerEnemies(GameObject[] enemies)
    {
        int expectedNum = 6;
        if (enemies.Length != expectedNum)
        {
            return;
        }
        tomatoSlicePos = new float[expectedNum, 3];
        for (int i = 0; i < enemies.Length; i++)
        {
            tomatoSlicePos[i, 0] = enemies[i].transform.position.x;
            tomatoSlicePos[i, 1] = enemies[i].transform.position.y;
            tomatoSlicePos[i, 2] = enemies[i].transform.position.z;
        }
    }

    public void AddDroppingFloors(GameObject[] dropFloors)
    {
        int expectedNum = 5;
        if (dropFloors.Length != expectedNum)
        {
            return;
        }
        tomatoSlicePos = new float[expectedNum, 3];
        for (int i = 0; i < dropFloors.Length; i++)
        {
            tomatoSlicePos[i, 0] = dropFloors[i].transform.position.x;
            tomatoSlicePos[i, 1] = dropFloors[i].transform.position.y;
            tomatoSlicePos[i, 2] = dropFloors[i].transform.position.z;
        }
    }
}
