using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI1 : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public GameObject bullet;
    public Transform shootPointL, shootPointR;

    public bool awake = false;
    public bool lookright = true;

    public float distance;
    public float wakerwall;
    public float bulletspeed;
    public float bullettime;
    public float bulletinterval;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookright);

        RangeCheck();
        if (target.transform.position.x > transform.position.x)
        {
            lookright = true;
        }

        if (target.transform.position.x < transform.position.x)
        {
            lookright = false;
        }

    }

    public void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        
        if (distance > wakerwall)
        {
            awake = false;
        }
        if (distance<wakerwall)
        {
            awake = true;
        }

    }

    public void attack(bool attackingright)
    {
        bullettime += Time.deltaTime;
        if (bullettime >= bulletinterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (attackingright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootPointL.transform.position, shootPointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettime = 0;
            }
            
            if (!attackingright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootPointR.transform.position, shootPointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettime = 0;
            }
        }
    }
}
