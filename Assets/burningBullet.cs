using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burningBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifetime = 2;
    public Rigidbody2D rb;

    public float speed = 3f;
    public float changeDir = -1f;

    
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("Dame", 1);
            }
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        

    }

    void FixedUpdate ()
    {
        Vector3 Movement = transform.localScale;
       


        if (Movement.x > 0)
        {
            rb.AddForce((Vector2.left) * speed * Time.deltaTime);
            
        }
        else if (Movement.x < 0)
        {
            rb.AddForce((Vector2.up) * speed * Time.deltaTime);
            
        }
    }

    
}
