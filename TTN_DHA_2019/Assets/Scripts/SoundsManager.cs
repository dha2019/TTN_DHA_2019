using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
    public static AudioClip HurtSound, JumpSound, ClimbSound,EnemySound,CoinSound,TeleportSound;
    public static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        HurtSound = Resources.Load<AudioClip>("Hurt");
        JumpSound = Resources.Load<AudioClip>("Jumping");
        ClimbSound = Resources.Load<AudioClip>("Climb");
        EnemySound = Resources.Load<AudioClip>("Enemy Die");
        CoinSound = Resources.Load<AudioClip>("Coin");
        TeleportSound = Resources.Load<AudioClip>("Teleport");



        //JumpSound = Resources.Load<AudioClip>("double jump");

        //CrouchSound = Resources.Load<AudioClip>("Crouch");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Hurt":
                audioSrc.PlayOneShot(HurtSound);
                break;
            case "Jumping":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "Climb":
                audioSrc.PlayOneShot(ClimbSound);
                break;
            case "Enemy Die":
                audioSrc.PlayOneShot(EnemySound);
                break;
            case "Coin":
                audioSrc.PlayOneShot(CoinSound);
                break;
            case "Teleport":
                audioSrc.PlayOneShot(TeleportSound);
                break;

                //case "double jump":
                //    audioSrc.PlayOneShot(JumpSound);
                //    break;
                //case "Crouch":
                //    audioSrc.PlayOneShot(CrouchSound);
                //    break;


        }
    }
}
