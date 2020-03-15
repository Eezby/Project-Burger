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

        HeartUI.sprite = 
            HeartSprites[player.GetComponent<PlayerController2D>().currentHealth];

    }
}
