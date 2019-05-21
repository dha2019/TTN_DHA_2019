using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_StupidPatrol : MonoBehaviour {

    //gioi han 2 diem di chuyen
    public Transform[] patrolPoints;
    public Transform currentPatrolPoint;
    public int currentPatrolPointIndex = 0;

    public float speed;
    public int curHealth = 100;
    private Animator anim;




    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();

        currentPatrolPoint = patrolPoints[currentPatrolPointIndex];
        if(currentPatrolPoint.position.x<transform.position.x)
        {
            speed = -1f;
        }
        else
        {
            speed = 1f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if(Vector2.Distance(currentPatrolPoint.position,transform.position)<.2f)
        {
            GetNextPatrolPoint();
        }
    }

    void GetNextPatrolPoint()
    {
        if (currentPatrolPointIndex < patrolPoints.Length - 1)
        {
            currentPatrolPointIndex++;
        }
        else
        {
            currentPatrolPointIndex = 0;
        }

        currentPatrolPoint = patrolPoints[currentPatrolPointIndex];

        if (currentPatrolPoint.position.x < transform.position.x)
        {
            speed = -1f;
            transform.localScale = new Vector3(1, 1, 1);                //chạm poitn trái sẽ quay mặt phải
        }
        else
        {
            speed = 1f;
            transform.localScale = new Vector3(-1, 1, 1);               //chạm point phải sẽ quay mặt trái

        }
    }

    public void Damage(int damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            StartCoroutine(Die());                     // hết máu sẽ bắt đầu chạy vòng lặp IEnumerator
            SoundsManager.PlaySound("Enemy Die");
        }
    }

    private IEnumerator Die()                         //scipts cùng collider attack của player sẽ tìm vl Die để thực hiện
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);       //enemy sẽ play animation die trước khi dùng hàm destroy để biến mất
        Destroy(gameObject);
    }
}
