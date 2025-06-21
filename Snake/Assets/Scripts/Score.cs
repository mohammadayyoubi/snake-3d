using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score = 0;

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
        void Update () {
                //get the score
                score = FruitRotator.count;
        }

        void OnGUI(){
                GUIStyle style = new GUIStyle();
                style.fontSize = 24;
                style.normal.textColor = Color.black;
                float width = 200;
                float height = 30;
                float x = (Screen.width - width) / 2f;
                GUI.Label(new Rect(x, 10, width, height), "Score: " + score, style);
        }
}
