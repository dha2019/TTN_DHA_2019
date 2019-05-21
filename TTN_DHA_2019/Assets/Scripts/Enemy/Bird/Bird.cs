using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public int curHealth = 100;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
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
