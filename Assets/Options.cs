using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public void Back()
    {
        
        if(SaveGameData.LoadData("/temp.dat") == null)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            PauseMenu pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
            pauseMenu.LoadGame("/temp.dat");
            SaveGameData.DeleteSave("/temp.dat");
        }
        
    }
}
