using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEagle : MonoBehaviour
{
    public float lifetime = 2;


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
            Destroy(gameObject);
    }
}