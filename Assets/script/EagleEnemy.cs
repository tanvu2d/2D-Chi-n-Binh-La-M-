using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : MonoBehaviour

{
    public Transform target;
    public bool lookRight = false;

    public Rigidbody2D rb;
    public Transform pointShoot;
    public GameObject bulletPrefap;

    public float bulletTime = 0;
    public float yimeShoot = 2;
    public float longstreet = 1f;
    public float dem = 0f;
    public float changeDir = -1f;
    public float speed = 1f;

    Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x > transform.position.x )
        {
            Vector3 Scale = transform.localScale;
            Scale.x = -1.874f;
            transform.localScale = Scale;

        }
        else
        {
            Vector3 Scale = transform.localScale;
            Scale.x = 1.874f;
            transform.localScale = Scale;
        }
        Attack();
        Move1();
    }
 
    void shoot ()
    {
        GameObject bullet = Instantiate(bulletPrefap, pointShoot.transform.position, pointShoot.transform.rotation);

    }

    void Attack ()
    {
        bulletTime += Time.deltaTime;
        if (bulletTime >= yimeShoot)
        {
            shoot();
            bulletTime = 0;
        }
    }
    void Move1 ()

    {
        dem += Time.deltaTime;
        Move.x += speed;
        transform.position = Move;
        
        if (dem >= longstreet)
        {
            speed *= changeDir;
            dem = 0;
        }
        
    }

}
