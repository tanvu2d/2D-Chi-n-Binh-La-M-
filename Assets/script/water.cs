using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeinwater = 0;
    public float timeDeath = 2f;
    public int dame = 1;
    public Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
 

    // Update is called once per frame
  

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))

        {
            timeinwater += Time.deltaTime;
            if (timeinwater >= timeDeath)
            {
            timeinwater = 0;
            player.Dame(dame);
            
            }
        }

    }
}
