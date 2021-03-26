﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFlat : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D r2;
    public float timedelay = 1f;

    void Start ()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.collider.CompareTag ("Player"))
        {
            StartCoroutine(fall());
        }
    }

    IEnumerator fall ()
    {
        yield return new WaitForSeconds(timedelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
