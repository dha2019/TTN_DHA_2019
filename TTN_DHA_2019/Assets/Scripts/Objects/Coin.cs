using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();          //KHởi tạo animation của Coin
    }

    public void DestroyCoin()
    {
        StartCoroutine(AnimationCoin());                     // Phương thức chạy vòng lặp Animationcoin và play sound
        SoundsManager.PlaySound("Coin");
    }

    private IEnumerator AnimationCoin()                 
    {
        anim.SetTrigger("Destroy");
        yield return new WaitForSeconds(0.5f);       //IEnumerator sẽ chạy theo từng bước. chạy animation Destroy xong 0.5s ms hủy vật thể
        Destroy(gameObject);
    }
}
