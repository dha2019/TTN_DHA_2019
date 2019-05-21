using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    void OntriggerEnter2D(Collider2D col)
    {
        player.grounded = false;
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    player.grounded = true;
    //}

    void OntriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }
}
