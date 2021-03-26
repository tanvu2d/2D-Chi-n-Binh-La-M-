using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conChon : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
   // public BoxCollider2D collider;


    public bool toRight = true;
    Vector3 Move;

    public float dem = 0f;
    public float longstreet = 3f;
    public float speed = 0.005f;
    public int damage = 1;
    public float changeDir = -1f;

    public float heathConChon = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        Move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (toRight)
        {
            Vector3 Scale = transform.localScale;
            Scale.x = -1.860379f;
            transform.localScale = Scale;

        }
        else if (!toRight)
        {
            Vector3 Scale = transform.localScale;
            Scale.x = 1.860379f;
            transform.localScale = Scale;
        }

        Move1();

        if (heathConChon <=0 )
        {
            Destroy(gameObject);
        }
    }




    void Move1()

    {
        dem += Time.deltaTime;
        Move.x += speed;
        transform.position = Move;

        if (dem >= longstreet)
        {
            speed *= changeDir;
            dem = 0;
            toRight = !toRight;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("Dame", 1);
                StartCoroutine(release());
            }
        }

    }
    
    IEnumerator release ()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().enabled = true;

    }
    void Damage(int dame)
    {
        heathConChon -= dame;
    }

}

