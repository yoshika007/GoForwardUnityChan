using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプ速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20;

    //ゲームオーバーになる位置
    private float deadLine = -70;

    public AudioClip jumpSE1;
    public AudioClip jumpSE2;
    public AudioClip jumpSE3;
    public AudioClip jumpSE4;

    public AudioClip deadSE1;
    public AudioClip deadSE2;
    public AudioClip deadSE3;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //アニメーターのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //RigidBody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        
        //着地状態でクリックされた場合
        if (Input.GetMouseButtonDown (0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);

            int num1 = Random.Range(1, 5);

            if (num1 == 1)
            {
                audioSource.PlayOneShot(jumpSE1);
            }
            else if (num1 == 2)
            {
                audioSource.PlayOneShot(jumpSE2);
            }
            else if (num1 == 3)
            {
                audioSource.PlayOneShot(jumpSE3);
            }
            else
            {
                audioSource.PlayOneShot(jumpSE4);
            }

        }

        //クリックをやめたら上方向への速度を減衰する
        if(Input.GetMouseButton (0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // デッドラインを超えた場合ゲームオーバにする
        if (transform.position.y < this.deadLine)
        {
            
            // ユニティちゃんを破棄する
            Destroy(gameObject);
        }

    }

    //outareaに衝突したらゲームオーバーUIと音声再生
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "outarea")
        {

            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();


            int num2 = Random.Range(1, 4);

            if(num2 == 1)
            {
                audioSource.PlayOneShot(deadSE1);
            }
            else if (num2 == 2)
            {
                audioSource.PlayOneShot(deadSE2);
            }
            else
            {
                audioSource.PlayOneShot(deadSE3);
            }

        }

    }

}
