using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is the class that other items will extend from.
//This allows the player to use different items using the same interface
public abstract class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PickUp(other.gameObject);
        }
    }
    public void PickUp(GameObject player)
    {
        Item[] old = player.GetComponent<PlayerController2D>().items;
        Item[] temp = new Item[old.Length + 1];
        for(int i = 0; i < old.Length; i++)
        {
            temp[i] = old[i];
        }
        temp[temp.Length - 1] = this;
        player.GetComponent<PlayerController2D>().items = temp;
    }
    public abstract void Use(GameObject player);
}
