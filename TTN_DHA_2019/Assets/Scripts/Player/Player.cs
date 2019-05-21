using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    //double jump
    private bool canyouJump = true;
    private int maxJump = 2;
    private int countJump=0;

    public bool grounded;


    //hien thi cot mau
    public int curHeath;
    public int maxHealth = 5 ;

    //menu game over
    public GameObject gameOverUI;

    //gameMaster đếm coin
    private Gamemaster gm;
    //gọi thuộc tính Coin trong Sript coin để chạy phương thức Destroy và chạy animation
    private Coin Coin;

    private Rigidbody2D r2bd;
    private Animator anim;

    void Start()
    {
        r2bd = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Gamemaster>();     //Khởi tạo đối tượng bộ đếm gm
        Coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coin>();               //khởi tạo đối tượng coin

        curHeath = maxHealth;                       // khi start thi thanh mau se max
    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal"))*speed);            // kiem tra gia tri tang dan khi an ban phim cho animtor Run

        //xoay mặt player
        if (r2bd.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);               //quay mat sang ben trai
        }
        if (r2bd.velocity.x > 0.1f)                                     //quay mat sang ben phai
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Jump & Double Jump
        if(Input.GetKeyDown(KeyCode.Space) )          
        {
            if (canyouJump == true)
            {
                SoundsManager.PlaySound("Jumping");

                countJump += 1;
                r2bd.AddForce(Vector2.up * jumpPower);
                anim.SetBool("IsJumping", true);
                
                if (countJump == 2)
                {
                    anim.SetBool("IsJumping", false);
                    anim.SetBool("IsFalling", false);
                    anim.SetBool("DoubleJump", true);
                }
                
            }

           if (countJump == maxJump)
            {
                canyouJump = false;
            }
        }

        #region old animator Jump

        //if (r2bd.velocity.y == 0)                                        //dung yen thi = 0   
        //{

        //    anim.SetBool("IsJumping", false);
        //    anim.SetBool("IsFalling", false);
        //    anim.SetBool("DoubleJump", false);

        //}

        //if ( && r2bd.velocity.y < 0)
        //{
        //    anim.SetBool("IsJumping", false);
        //    anim.SetBool("IsFalling", true);
        //}

        //if (r2bd.velocity.y > 10)                                      // chay lien tuc co the lam tang gia tri velocity
        //{
        //    anim.SetBool("IsJumping", true);                            //van toc cua y khi player nhay len se > 0
        //}


        #endregion
        //Nhảy lần 1 và trong trạng thái đang rơi sẽ set trigger animation IsFalling
        if (countJump == 1 && r2bd.velocity.y < 0)                   
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);
        }

        //Trạng thái ấn button và nhả button sẽ set animation trigger Teleport
        if(Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Teleport", true);
            SoundsManager.PlaySound("Teleport");

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("Teleport", false);
        }

        //Kiểm tra máu của nhân vật chỉ = maxHealth, nhỏ hơn 0 sẽ chạy phương thức Die
        if (curHeath > maxHealth)
        {
            curHeath = maxHealth;
        }
        if (curHeath <= 0)
        {
            Die();
        }  
    }

    //Check ground - Để trả trạng thái player về ban đầu
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.tag == "Ground")
        {
            countJump = 0;
            canyouJump = true;
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
            anim.SetBool("DoubleJump", false);
        }
    }

    //di chuyen
    void FixedUpdate()
    {
        //bắt nhận bàn phím để di chuyển player
        float h = Input.GetAxis("Horizontal");       
        r2bd.AddForce((Vector2.right * speed) * h);

        //tốc độ giới hạn của player
        if(r2bd.velocity.x > maxSpeed)
        {
            r2bd.velocity = new Vector2(maxSpeed, r2bd.velocity.y);
        }

        if(r2bd.velocity.x<-maxSpeed)
        {
            r2bd.velocity = new Vector2(-maxSpeed, r2bd.velocity.y);
        }
    }

    // Die thì sẽ chạy UX/UI GameOver và Destroy object player
    void Die()
    {
        gameOverUI.SetActive(true);
        Destroy(gameObject);
    }

    //Dame khi dính Spike 
    public void Damage(int dmg)
    {
        SoundsManager.PlaySound("Hurt");

        curHeath -= dmg;
        // animation trigger Hurt khi player gap phai spikes
        anim.SetTrigger("Hurt");
    }

    //Animation leo thang
    public void Climb()         //Phương thức được gọi bên script Ladder
    {                                                
        anim.SetBool("IsClimb", true);                     //trạng thái va trạm vs Ladder
        SoundsManager.PlaySound("Climb");
    }
    public void OutClimb()                                 //trạng thái out ladder
    {
        anim.SetBool("IsClimb", false);
    }

    //knockback khi dinh dame
    public IEnumerator Knockback(float knockDur,float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        r2bd.velocity = new Vector2(0, 0);                                         //dat van toc ve 0 truoc khi them AddForce
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            r2bd.AddForce(new Vector3(knockbackDir.x, knockbackDir.y + knockbackPwr, transform.position.z));
        }

        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {                                       //Khi player va trạm trigger sẽ tìm kiếm tag Coin
        if (col.CompareTag("Coin"))         //và kích hoạt phương thức DestroyCoin của coin và đồng thời +1 vào bộ đếm Gamemaster
        {
            Coin.DestroyCoin();
            gm.points += 1;
        }
    }
}
