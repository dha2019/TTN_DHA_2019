using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Down_Platform : MonoBehaviour {

    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.15f);                      // invoke sẽ thực hiện phương thức Fall trong khoảng thời gian 0.15
            Destroy(gameObject, 2f);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
    }

}
