using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public string level;

    public int currentHealth;
    public int maxHealth;
    public int currentLives;

    public float moveSpeed;
    public float jumpForce;
    public float[] playerPosition;

    // level 1
    public float[] mousePosition;
    public float[] mouseScale;
    public float[,] fallingObjPosition;
    public float[,] fallingObjScale;
    public float[] enemyPosistion;
    public float[] enemyScale;
    public float[,] droppingFloorPos;
    public float[,] droppingFloorScale;

    // level 2
    public float[,] tomatoSlicePos1;
    public float[,] tomatoSliceScale1;
    public float[,] tomatoSlicePos2;
    public float[,] tomatoSliceScale2;
    public float[,] burgerEnemiesPos;
    public float[,] burgerEnemiesScale;

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

        level = SceneManager.GetActiveScene().name;
    }

    public void AddMouse(GameObject mouse)
    {
        if (mouse == null) { return; }
        mousePosition = new float[3];
        mouseScale = new float[3];

        mousePosition[0] = mouse.transform.position.x;
        mousePosition[1] = mouse.transform.position.y;
        mousePosition[2] = mouse.transform.position.z;

        mouseScale[0] = mouse.transform.localScale.x;
        mouseScale[1] = mouse.transform.localScale.y;
        mouseScale[2] = mouse.transform.localScale.z;
    }

    public void AddEnemy(GameObject enemy)
    {
        if(enemy == null) { return; }
        enemyPosistion = new float[3];
        enemyScale = new float[3];

        enemyPosistion[0] = enemy.transform.position.x;
        enemyPosistion[1] = enemy.transform.position.y;
        enemyPosistion[2] = enemy.transform.position.z;

        enemyScale[0] = enemy.transform.localScale.x;
        enemyScale[1] = enemy.transform.localScale.y;
        enemyScale[2] = enemy.transform.localScale.z;
    }

    public void AddFallingObjs(GameObject[] tomatos)
    {
        //int expectedNum = 3;
        //if(tomatos.Length != expectedNum)
        //{
        //    return;
        //}
        int expectedNum = tomatos.Length;
        fallingObjPosition = new float[expectedNum, 3];
        fallingObjScale = new float[expectedNum, 3];
        for (int i = 0; i < tomatos.Length; i++)
        {
            fallingObjPosition[i, 0] = tomatos[i].transform.position.x;
            fallingObjPosition[i, 1] = tomatos[i].transform.position.y;
            fallingObjPosition[i, 2] = tomatos[i].transform.position.z;

            fallingObjScale[i, 0] = tomatos[i].transform.localScale.x;
            fallingObjScale[i, 1] = tomatos[i].transform.localScale.y;
            fallingObjScale[i, 2] = tomatos[i].transform.localScale.z;
        }
    }

    public void AddTomatoSlices1(GameObject[] tomatos)
    {
        int expectedNum = tomatos.Length;
        //if (tomatos.Length != expectedNum)
        //{
        //    return;
        //}
        tomatoSlicePos1 = new float[expectedNum, 3];
        tomatoSliceScale1 = new float[expectedNum, 3];
        for (int i = 0; i < tomatos.Length; i++)
        {
            if(tomatos[i] != null)
            {
                tomatoSlicePos1[i, 0] = tomatos[i].transform.position.x;
                tomatoSlicePos1[i, 1] = tomatos[i].transform.position.y;
                tomatoSlicePos1[i, 2] = tomatos[i].transform.position.z;

                tomatoSliceScale1[i, 0] = tomatos[i].transform.localScale.x;
                tomatoSliceScale1[i, 1] = tomatos[i].transform.localScale.y;
                tomatoSliceScale1[i, 2] = tomatos[i].transform.localScale.z;
            }
        }
    }

    public void AddTomatoSlices2(GameObject[] tomatos)
    {
        int expectedNum = tomatos.Length;
        //if (tomatos.Length != expectedNum)
        //{
        //    return;
        //}
        tomatoSlicePos2 = new float[expectedNum, 3];
        tomatoSliceScale2 = new float[expectedNum, 3];
        for (int i = 0; i < tomatos.Length; i++)
        {
            if (tomatos[i] != null)
            {
                tomatoSlicePos2[i, 0] = tomatos[i].transform.position.x;
                tomatoSlicePos2[i, 1] = tomatos[i].transform.position.y;
                tomatoSlicePos2[i, 2] = tomatos[i].transform.position.z;

                tomatoSliceScale2[i, 0] = tomatos[i].transform.localScale.x;
                tomatoSliceScale2[i, 1] = tomatos[i].transform.localScale.y;
                tomatoSliceScale2[i, 2] = tomatos[i].transform.localScale.z;
            }
        }
    }

    public void AddBurgerEnemies(GameObject[] enemies)
    {
        int expectedNum = enemies.Length;
        //if (enemies.Length != expectedNum)
        //{
        //    return;
        //}
        burgerEnemiesPos = new float[expectedNum, 3];
        burgerEnemiesScale = new float[expectedNum, 3];
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] != null)
            {
                burgerEnemiesPos[i, 0] = enemies[i].transform.position.x;
                burgerEnemiesPos[i, 1] = enemies[i].transform.position.y;
                burgerEnemiesPos[i, 2] = enemies[i].transform.position.z;

                burgerEnemiesScale[i, 0] = enemies[i].transform.localScale.x;
                burgerEnemiesScale[i, 1] = enemies[i].transform.localScale.y;
                burgerEnemiesScale[i, 2] = enemies[i].transform.localScale.z;
            }
        }
    }

    public void AddDroppingFloors(GameObject[] dropFloors)
    {
        int expectedNum = dropFloors.Length;
        //if (dropFloors.Length != expectedNum)
        //{
        //    return;
        //}
        droppingFloorPos = new float[expectedNum, 3];
        droppingFloorScale = new float[expectedNum, 3];
        for (int i = 0; i < dropFloors.Length; i++)
        {
            if(dropFloors[i] != null)
            {
                droppingFloorPos[i, 0] = dropFloors[i].transform.position.x;
                droppingFloorPos[i, 1] = dropFloors[i].transform.position.y;
                droppingFloorPos[i, 2] = dropFloors[i].transform.position.z;

                droppingFloorScale[i, 0] = dropFloors[i].transform.localScale.x;
                droppingFloorScale[i, 1] = dropFloors[i].transform.localScale.y;
                droppingFloorScale[i, 2] = dropFloors[i].transform.localScale.z;
            }
        }
    }
}
