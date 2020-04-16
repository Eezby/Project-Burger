using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject player;
	public int DamageAmount;

	public float knockbackPower;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals ("BurgerMan"))
			rb.isKinematic = false;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name.Equals ("BurgerMan"))
		{
			player.GetComponent<PlayerController2D>().Damage(DamageAmount);
			StartCoroutine(player.GetComponent<PlayerController2D>().
				Knockback(0.1f, knockbackPower, player.transform.position));
		}
	}

}
