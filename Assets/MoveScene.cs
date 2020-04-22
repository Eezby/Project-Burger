using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MoveScene : MonoBehaviour
{
    [SerializeField]
    private string Level;
    private int nextSceneToLoad;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Level);
        }
    }
}
