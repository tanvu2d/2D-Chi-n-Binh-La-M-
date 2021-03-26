using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burning : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
    public Transform pointShootUp;
    public Transform pointShootDown;
    public GameObject bulletPrefap;

    public float Health = 200f;

    public float bulletTime = 0;
    public float yimeShoot = 2;
    // public BoxCollider2D collider;


    public bool toRight = true;
    Vector3 Move;

    public float dem = 0f;
    public float longstreet = 3f;
    public float speed = 0.005f;
    public int damage = 1;
    public float changeDir = -1f;

    

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

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        Attack();
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



    void Damage(int dame)
    {
        Health -= dame;
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefap, pointShootUp.transform.position, pointShootUp.transform.rotation);
        GameObject bullet1 = Instantiate(bulletPrefap, pointShootDown.transform.position, pointShootDown.transform.rotation);
    }

    void Attack()
    {
        bulletTime += Time.deltaTime;
        if (bulletTime >= yimeShoot)
        {
            shoot();
            bulletTime = 0;
        }
    }
}
