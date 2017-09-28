using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	//スコアを表示するテキスト
	private GameObject scoreText;
	//スコアの変数
	private int point;


	// Use this for initialization
	void Start () {
		point = 0;
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text> ().text = "Score : "+ point ;
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "SmallStarTag") {
			this.point = this.point + 10;
		} else if (collision.gameObject.tag == "LargeStarTag") {
			point = point + 20;
		} else if (collision.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			point = point + 50;
		}
		this.scoreText.GetComponent<Text> ().text = "Score : "+ point ;
		Debug.Log (point);
	}

}