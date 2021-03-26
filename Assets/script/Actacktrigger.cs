using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actacktrigger : MonoBehaviour
{
    public int dame = 20;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void OnTriggerEnter2D (Collider2D  col)
    {
        if (col.isTrigger == false && col.CompareTag("Enemy")) 
        {
            col.SendMessageUpwards("Damage", dame);
        }
        
    }
   
}
