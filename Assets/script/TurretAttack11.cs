using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack11 : MonoBehaviour
{
    public TurretAI1 turret;
    public bool isLeft = true ;
    // Start is called before the first frame update
    void Start()
    {
        turret = gameObject.GetComponentInParent<TurretAI1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                turret.attack(true);
            }
            else
            {
                turret.attack(false);
            }
        }
    }
}
