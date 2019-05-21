using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed;
    public float MinDistance;                       //so o be nhat de enemy dung lai
    public float MaxDistance;                       //so o lon nhat de enemy dung lai

    private Transform target;

    private bool facingRight = true;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();                  //tim doi tuong co tag "player"
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(transform.position, target.position) > MinDistance && Vector2.Distance(transform.position, target.position) < MaxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (target.position.x < transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
                Flip();
            if (target.position.x > transform.position.x && facingRight)
                Flip();
        }
        
        //LookAtTarget();
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    //private void LookAtTarget()
    //{
    //    if(target!=null)
    //    {
    //        float xDir = target.transform.position.x - transform.position.x;
    //        if(xDir<0 &&facingRight)
    //        {
    //            transform.localScale = new Vector3(1, 1, 1);
    //        }
    //        else if (xDir > 0 && !facingRight)
    //        {
    //            transform.localScale = new Vector3(-1, 1, 1);
    //        }
    //    }
    //}
}
