using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbike : MonoBehaviour
{
    public Player player;
    public int damage = 2; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D (Collider2D col )
    {
        if (col.CompareTag("Player") )

        {
            player.Dame(damage);
            player.Knockback(400f, player.transform.position);
        }
         
    }
}
