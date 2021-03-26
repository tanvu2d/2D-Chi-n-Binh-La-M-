using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActack : MonoBehaviour
{
    public float  actackdelay = 0.3f ;
        public bool actacking = false;
    public Animator anim;
    public Collider2D trigger;

    public SoundManager sound;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;

    }
    void Start ()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Z) && !actacking  )
        {
            actacking = true;
            trigger.enabled = true;
            actackdelay = 0.3f;
            sound.Playsound("attack");
        }
        if (actacking)
        {
            if (actackdelay > 0)
            {
                actackdelay -= Time.deltaTime;
            }
            else
            {
                actacking = false;
                trigger.enabled = false;    
            }
        }
        anim.SetBool("Actacking", actacking);
    }
}
