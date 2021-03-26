using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groudcheck : MonoBehaviour
{
    public Player player;
    public FlatMoving mov;

    public Vector3 movep;
    // Start is called before the first frame update
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Movingflat").GetComponent<FlatMoving>();
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false)
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
        {
            player.grounded = true;
        }
        if (collision.isTrigger == false && collision.CompareTag("Movingflat"))
        {
            movep = player.transform.position;
            movep.x += mov.speed * 1.3f;
            player.transform.position = movep;
        }
    }
    private void OnTriggerExit2D(Collider2D collision )
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = false;
    }
}
