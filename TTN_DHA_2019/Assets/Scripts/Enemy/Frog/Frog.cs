using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    //public float maxSpeed = 3;
    //public float speed = 50f;
    //public float jumpPower = 150f;
    private Gamemaster gm;

    //private Rigidbody2D frog;

    // Use this for initialization
    void Start () {
        //frog = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Gamemaster>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (frog.velocity.x < -0.01f)
        //{
        //    frog.transform.localScale = new Vector3(-1, 1, 1);               //quay mat sang ben trai
        //}
        //if (frog.velocity.x > 0.01f)                         //quay mat sang ben phai
        //{
        //    frog.transform.localScale = new Vector3(1, 1, 1);
        //}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.GuideText.text = ("Ấn [E] để Teleport, Double Jump để tấn công !");  //gọi đến biến GuideText để hiện hướng dẫn

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.GuideText.text = ("");
        }
    }

}
