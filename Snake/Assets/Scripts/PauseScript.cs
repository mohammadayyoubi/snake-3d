using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
	
	public Text pauseText;

	void Start(){
		pauseText.gameObject.SetActive(false);
	}


	public void pauseTheGame(){
		if(Time.timeScale == 1){
			//game not paused
			Time.timeScale = 0;				//pause the game
			pauseText.gameObject.SetActive(true);
		}else if(Time.timeScale == 0){
			//game paused
			Time.timeScale = 1;				//continue the game
			pauseText.gameObject.SetActive(false);
		}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                // Game not paused
                Time.timeScale = 0; // Pause the game
                pauseText.gameObject.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                // Game is paused
                Time.timeScale = 1; // Resume the game
                pauseText.gameObject.SetActive(false);
            }
        }
    }

}
