using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    //ゲームオーバーテキスト
    private GameObject gameOberText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 2f;

    //ゲームオーバーの判定
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameOberText  = GameObject.Find ("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {

            //走った距離を更新する
            this.len += this.speed * Time.deltaTime;

            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";

        }

        //ゲームオーバーになった場合
        if (this.isGameOver == true)
        {
            //クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //SampleSceneを読み込む
                SceneManager.LoadScene("SampleScene");
            }
        }

    }

    public void GameOver()
    {
        //ゲームオーバーになった時、画面上にゲームオーバーを表示する
        this.gameOberText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }

}
