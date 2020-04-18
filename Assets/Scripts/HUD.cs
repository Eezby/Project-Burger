using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    
    public Sprite[] HeartSprites;
    
    public Image HeartUI;

    public GameObject player;
    private int playerHealth;

    

    void Update(){

        if (player.GetComponent<PlayerController2D>().currentHealth <= 0)
        {
            player.GetComponent<PlayerController2D>().currentHealth = 0;
        }
            HeartUI.sprite = 
            HeartSprites[player.GetComponent<PlayerController2D>().currentHealth];

    }
}
