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
                GUI.Label(new Rect(10,10,200,30), "Score: " + score, style);
        }
}
