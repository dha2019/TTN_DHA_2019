using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
    public int dmg = 20;
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger!=true && col.CompareTag("Enemy"))        //Kiểm tra object có tag enemy sẽ tìm pt Damage trong
                                                                // đó để gửi message tính dame
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
