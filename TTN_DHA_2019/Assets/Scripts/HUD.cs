using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //su dung egine UI cua Unity moi du dung duoc Image

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartUI;

    private Player player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHeath];
    }

}
