<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    //public Collider2D col;
    public GameObject player;
    public int DamageAmount;

    public float knockbackPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")){
            player.GetComponent<PlayerController2D>().Damage(DamageAmount);
            StartCoroutine(player.GetComponent<PlayerController2D>().
                Knockback(0.1f,knockbackPower,player.transform.position));
        }
        
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    //public Collider2D col;
    public GameObject player;
    public int DamageAmount;

    public float knockbackPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")){
            player.GetComponent<PlayerController2D>().Damage(DamageAmount);
            StartCoroutine(player.GetComponent<PlayerController2D>().
                Knockback(0.1f,knockbackPower,player.transform.position));
        }
        
    }
}
>>>>>>> master
