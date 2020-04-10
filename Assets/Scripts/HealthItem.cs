using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public new void PickUp(GameObject player)
    {
        player.GetComponent<PlayerController2D>().currentHealth += 1;
        Destroy(gameObject);
    }

    public override void Use(GameObject player)
    {

    }
}
