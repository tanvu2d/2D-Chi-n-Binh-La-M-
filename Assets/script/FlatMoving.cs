﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f, changeDir = -1;
    Vector3 Move;
    public PauseMenu pausep;

    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;
        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausep.pause)
        {
            this.transform.position = this.transform.position;

        }
        if (pausep.pause == false)
        {
            Move.x += speed;
            this.transform.position = Move;
        }



    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("ground"))
        {
            speed *= changeDir;
        }
    }
}
