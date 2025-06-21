using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

        void Awake(){
                if(startButton != null)
                        startButton.gameObject.SetActive(false);
        }

	AsyncOperation ao;
	public Text loadingText;
	public Button startButton;

	public void LoadLevel (string name){
		Debug.Log("Loaded Level: "+name);
		//Application.LoadLevel(name);
		SceneManager.LoadScene(name);
	}
	
	public void QuitLevel (){
		Debug.Log("Quit");
		Application.Quit();
	}
	
        public void LoadNextLevel(){
                int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if(nextIndex < SceneManager.sceneCountInBuildSettings){
                        SceneManager.LoadScene(nextIndex);
                }else{
                        SceneManager.LoadScene(0);
                }
        }

        void OnGUI(){
                if(SceneManager.GetActiveScene().name == "Start"){
                        int width = 200;
                        int height = 40;
                        float x = Screen.width/2 - width/2;
                        float y = Screen.height/2 - height;
                        if(GUI.Button(new Rect(x, y, width, height), "Level 1")){
                                LoadLevel("Level1");
                        }
                        if(GUI.Button(new Rect(x, y + 50, width, height), "Level 2")){
                                LoadLevel("Level2");
                        }
                }
        }

	//loading the game scene
	public void loadingGame(){
		//hide start button
		startButton.gameObject.SetActive(false);

		//show Loading text
		loadingText.gameObject.SetActive(true);
		StartCoroutine(loadGameWithProgress());
	}


	//loading with progress
	IEnumerator loadGameWithProgress(){
		yield return new WaitForSeconds(1);

		ao = SceneManager.LoadSceneAsync(1);

		ao.allowSceneActivation = false;

		while(!ao.isDone){
			Debug.Log("Loading ...");

			if(ao.progress == 0.9f){ //level is completely loaded
				ao.allowSceneActivation = true;
			}

			Debug.Log(ao.progress);
			yield return null;
		}
	}
}
