using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //private bool attacking = false;
    //private float attacTimer = 0;
    //private float attackCd = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;

    //double jump
    private bool canyouJump = true;
    private int howmanyJump = 2;
    private int countJump = 0;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;                  //tat trigger collider khi bat dau
    }

    // Update is called once per frame
    void Update()
    {
        #region old attack damgae
        //if(Input.GetKeyDown("f")&& !attacking)
        //{
        //    attacking = true;
        //    attacTimer = attackCd;               // tan cong theo thoi gian cua ttackCD

        //    attackTrigger.enabled = true;
        //}

        //if(attacking)
        //{
        //    if(attacTimer>0)
        //    {
        //        attacTimer -= Time.deltaTime;    //thoi gian se giam dan theo thoi gian thuc
        //    }
        //    else
        //    {
        //        attacking = false;
        //        attackTrigger.enabled = false;       //tat colider trigger damage
        //    }
        //}
        #endregion

        // anim.SetBool("Attacking",attacking);          //animation attack old

        //double jump
        if (Input.GetKeyDown(KeyCode.Space) )          
        {
            if (canyouJump == true)
            {
                countJump += 1;
               
                if (countJump == 2)                                    //neu double jump se kich hoat collider trigger damage
                {
                    attackTrigger.enabled = true;                         
                }

            }
            if (countJump == howmanyJump)
            {
                canyouJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)                
    {
        if (col.gameObject.tag == "Ground")         //double jump cham dat thi reset collider trigger damage
        {
            countJump = 0;  
            canyouJump = true;

            attackTrigger.enabled = false;                  
        }
    }
}
