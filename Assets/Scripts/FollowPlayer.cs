using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float speed;
    private Transform target;


    public Transform groundDetection;
    private bool movingRight = true;
    public float groundDistance;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDistance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                //var targetPos = new Vector2(target.position.x, transform.position.y);
                //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                //var targetPos = new Vector2(target.position.x, transform.position.y);
               // transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        //these two lines of code force the object to move across the x axis
        //var targetPos = new Vector2(target.position.x, transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //comment both lines above and uncomment line below to add in "flying" movement
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  

    }


}