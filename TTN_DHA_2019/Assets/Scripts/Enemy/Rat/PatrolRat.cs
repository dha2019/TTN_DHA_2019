using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRat : MonoBehaviour {
    public float speed;
    public float distance;
    public int curHealth = 1000;

    private bool movingRight = true;

    public Transform groundDetection;
    private Animator anim;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);                 //enemies rat có mặt quay sang bên trái

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider==false)
        {
            if(movingRight==true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

       
	}


    public void Damage(int damage)
    {
        curHealth -= damage;
        
        if (curHealth <= 0)
        {
            StartCoroutine(Die());                     // hết máu sẽ bắt đầu chạy vòng lặp IEnumerator
        }
    }

    private IEnumerator Die()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);       //enemy sẽ play animation die trước khi dùng hàm destroy để biến mất
        Destroy(gameObject);
    }
}
