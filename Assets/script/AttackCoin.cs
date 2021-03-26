using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public TurretAI turret;
    public bool isLeft = false;


    private void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretAI>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
                turret.Attack(false);

            else
                turret.Attack(true);


        }
    }
}
