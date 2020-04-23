using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;

    
    [SerializeField]
    Transform groundCheckM;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;
    public Animator animator;                           
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    //stats
    public int currentHealth;
    public int maxHealth = 3;

    public static int livesValue = 3;
    public Text lives;

    public int currentLives;


    public GameObject FrenchFryPrefab;
    public float attackDelay = 0;

    //public bool Moving { get { return Moving; } }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //lives = GetComponent<Text>();
        currentHealth = maxHealth;
        currentLives = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lives.text = "Lives: " + livesValue;
        // sends a line from player to grouncheck object position,
        // if line encounters anything on layer "ground", object is considered grounded
        if ((Physics2D.Linecast(transform.position, groundCheckM.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
           (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))) {
                isGrounded = true;
            animator.SetBool("isJumping", false);       //added from master
        } else{
                isGrounded = false;
                animator.SetBool("isJumping", true);    //added from master
            //  animator.Play("Player_jump");
        }
        // movement right
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2d.velocity = new Vector2(moveSpeed,rb2d.velocity.y);
            spriteRenderer.flipX = false;
        //  if(isGrounded){
        //  animator.Play("Player_run");}
        }
        
        //movement left
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2d.velocity = new Vector2(-moveSpeed,rb2d.velocity.y);
            spriteRenderer.flipX = true;
        //  if(isGrounded){
        //  animator.Play("Player_run");}
        } else{
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        //  if(isGrounded){
        //  animator.Play("Player_run");}
        }

        // player jumping
        if(Input.GetKeyDown("space") && isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            SoundManagerScript.PlaySound ("jump");
        //  animator.Play("Player_jump");
        }

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0){
            currentHealth = 0;
            //NOT WORKING AS INTENDID DO NOT PLAY WITH HIGH VOLUME
            /*SoundManagerScript.PlaySound("death");
            StartCoroutine(Waitfordeath());*/

            Die();

        }
        //Added from master
        attackDelay -= Time.deltaTime;
        if (Input.GetKeyDown("x"))
        {
            Attack();
        }

        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
    }

    void Die(){
         //Application.LoadLevel(Application.loadedLevel);   // supposedly outdated, we'll see
        livesValue = livesValue -1;
        //////////////////////////////////////////////////////GAMEOVER add gameover scene
       
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    //NOT WORKING AS INTENDID DO NOT PLAY WITH HIGH VOLUME
    /*public IEnumerator Waitfordeath()
    {
        yield return new WaitForSeconds(1f);
        Die();

    }*/

    public void Damage(int damage){

        currentHealth -= damage;

    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Vector3 knockbackDirection){
        
        float timer = 0;

        while(knockbackDuration > timer){
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockbackDirection.x + -10,
                knockbackDirection.y + knockbackPower, transform.position.z));
        }

        yield return 0;
    }

    //Added from master
    public void Attack()
    {
        //Check if delay between attacks has expired
        if (attackDelay <= 0)
        {
            //Create projectile object and set it's position to the player's position
            GameObject fry = Instantiate(FrenchFryPrefab) as GameObject;
            fry.transform.position = rb2d.transform.position;
            //flip velocity if the player is turned arround
            if (spriteRenderer.flipX)
            {
                fry.GetComponent<FrenchFry>().speed = -fry.GetComponent<FrenchFry>().speed;
            }
            //if the player is moving, make the projectile move faster with the player
            fry.GetComponent<FrenchFry>().speed.x += rb2d.velocity.x;

            attackDelay = 0.5f;
        }

    }


}
