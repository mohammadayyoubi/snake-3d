using UnityEngine;
using System.Collections;

public class HeadCollision : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//get level manager
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("Head Trigger");

                //collide with bodyPart or enemy
                if(other.gameObject.CompareTag("BodyPart") || other.gameObject.CompareTag("Enemy")){
                        Debug.Log("Triggred With BodyPart or Enemy");
                        //goto lose screen
                        levelManager.LoadLevel("Lose");
                }
	}

}
