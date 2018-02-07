using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Vector3 preMousePos;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DrugMove ();
	}
		


	//指の移動量に応じてPlayerを移動させる関数
	void DrugMove(){

		//タッチした瞬間のマウスの座標をpreMousePosに格納
		if (Input.GetMouseButtonDown (0)) {
			preMousePos = Input.mousePosition;
		}



		if (Input.GetMouseButton (0)) {
			Vector3 deltaMousePos = Input.mousePosition - preMousePos;//マウスの現在位置と直近のマウスの位置(preMousePosの差分をとる)
			//→その差分を変数deltaMousePosに格納

			//preMousePosに現在のマウスの位置を格納(→次のフレームの処理で使う為)
			preMousePos = Input.mousePosition;


			Vector3 newPos = this.gameObject.transform.position + new Vector3 (deltaMousePos.x / Screen.width,deltaMousePos.y / Screen.width, 0) * speed;
			//Screen.widthを分母に置いているのは、端末毎に異なる画面サイズに適応する為に『画面幅に対してどれだけの割合移動したのか』を算出→speedの値をかけている！



			//===画面外にPlayerがいかないようにする工夫===
			if (newPos.x > 9.0f) {
				newPos = new Vector3 (9.0f, newPos.y, newPos.z);
			}
			if (newPos.x < -9.0f) {
				newPos = new Vector3 (-9.0f, newPos.y, newPos.z);
			}
			if (newPos.y > 6.0f) {
				newPos = new Vector3 (newPos.x, 6.0f, newPos.z);
			}
			if (newPos.y < -4.0f) {
				newPos = new Vector3 (newPos.x, -4.0f, newPos.z);
			}


			//上の文をこの文の直上に入れておくと、画面外への移動を制限することができる！
			this.transform.position = newPos;
		}
	}
		
}
