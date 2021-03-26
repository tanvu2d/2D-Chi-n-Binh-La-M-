using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public float speed = 50f, maxspeed = 3, maxjump = 4 ,  jumpPow = 220f;
    public int ourHealth;
    public int maxHeath = 500;
    public Rigidbody2D r2;
    public Animator anim;
    public  bool grounded = true  , faceright = true , doubleJump = true  ;
    public gamemaster gm;
    public SoundManager sound;

    // time in the water
    
    // Start is called before the first frame update
    void Start()
    {
        r2 =   gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxHeath;
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update() 
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x)) ;  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doubleJump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    r2.velocity = new Vector2 (r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.5f); 
                }
            }
        }
    }
    void  FixedUpdate ()
    {
        // set up move to left or right 
        float h = Input.GetAxis("Horizontal");

        r2.AddForce((Vector2.right) * speed * h);

        // limited velocity 

        if (r2.velocity.x > maxspeed)
        {
            // position
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        }

        if (r2.velocity.x < -maxspeed)
        {
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }
        if (r2.velocity.y > maxjump)
        {
            r2.velocity = new Vector2(r2.velocity.x, maxjump);
        }
        if (r2.velocity.y < -maxjump)
        {
            r2.velocity = new Vector2(r2.velocity.x, -maxjump);
        }
        // dieu kien de lat player Flip ( )
        if (h > 0 && !faceright)
        {
            Flip();

        }
        if (h <0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            // loi ma sat 
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }
        if (ourHealth <= 0)
        {
            Death();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale ;

    }
    public void Death ()
    {
        // Load lai man hien tai
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highscore") < gm.points)
            PlayerPrefs.SetInt("highscore", gm.points);
    }
    public void Dame (int dame)
    {
        ourHealth -= dame;
        gameObject.GetComponent<Animation>().Play("redflat"); 
    }
    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y  + Knockpow));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coins"))
        {
            sound.Playsound("coins");
            Destroy(col.gameObject);
            gm.points += 1;
        }
    }

}
