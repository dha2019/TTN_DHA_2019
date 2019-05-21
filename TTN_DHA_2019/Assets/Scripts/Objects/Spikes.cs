using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private Player player;

    [SerializeField]
    private int Damage = 1;
    [SerializeField]
    private Animator AnimationController;
    [SerializeField]
    private int DamageY = 350;
    [SerializeField]
    private float DamageX = 0.02f;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    //trigger khi player gap spikes
    void OnTriggerEnter2D(Collider2D col)                                     //OnTriggerEnter2D viet thuong se khong hoat dong !!!
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(Damage);

            StartCoroutine(player.Knockback(DamageX, DamageY, player.transform.position));                         //knockback khi player gap spikes

        }
    }

}
