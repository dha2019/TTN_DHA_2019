using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_PF_LR : MonoBehaviour
{
    public float RightPlatform = 0f;
    public float LeftPlatform = 0f;

    public float moveSpeed = 3f;
    bool moveRight = true;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > RightPlatform)
            moveRight = false;
        if (transform.position.x < LeftPlatform)
        {
            moveRight = true;
        }

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            moveRight = true;
            col.collider.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.collider.transform.SetParent(null);
        }
    }//Giup nhan vat dung yen tren Moving Platform
}
