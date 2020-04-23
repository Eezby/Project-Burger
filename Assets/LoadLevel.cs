using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string LevelName;

    // Start is called before the first frame update
    //private void Start()
   // {
        //scenetoload = SceneManager.GetActiveScene().buildIndex + 1;
   // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}