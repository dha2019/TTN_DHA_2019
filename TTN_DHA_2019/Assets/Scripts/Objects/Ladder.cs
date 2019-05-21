using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    //toc do leo thang
    public float speed = 6;   //Độ dài leo được khi trên thang
    public float smooth=0;

    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //kich hoat animator Climb
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.Climb();                   
        }
    }

    //animation idle khi thoat ra khoi trigger
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.OutClimb();
        }
    }

    //khi dang tiep xuc voi collider trigger ladder
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (col.tag == "Player" && Input.GetKey(KeyCode.DownArrow))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
           col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, smooth);
        }
    }
}
