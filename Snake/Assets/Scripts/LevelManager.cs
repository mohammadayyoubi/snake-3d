using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System;

public class LevelManager : MonoBehaviour {

        public static Type pendingSettings;

        void Awake(){
                if(startButton != null)
                        startButton.gameObject.SetActive(false);
        }

        void OnEnable(){
                SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable(){
                SceneManager.sceneLoaded -= OnSceneLoaded;
        }

	AsyncOperation ao;
	public Text loadingText;
	public Button startButton;

        public void LoadLevel (string name){
                Debug.Log("Loaded Level: "+name);
                if(name == "Level1") pendingSettings = typeof(Level1Settings);
                else if(name == "Level2") pendingSettings = typeof(Level2Settings);
                else if(name == "Level3") pendingSettings = typeof(Level3Settings);

                SceneManager.LoadScene(name);
        }
	
	public void QuitLevel (){
		Debug.Log("Quit");
		Application.Quit();
	}
	
        public void LoadNextLevel(){
                int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
                string nextName = SceneManager.GetSceneByBuildIndex(nextIndex).name;
                if(nextIndex < SceneManager.sceneCountInBuildSettings){
                        if(nextName == "Level2") pendingSettings = typeof(Level2Settings);
                        else if(nextName == "Level3") pendingSettings = typeof(Level3Settings);
                        else pendingSettings = null;
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
                        if(GUI.Button(new Rect(x, y + 100, width, height), "Level 3")){
                                LoadLevel("Level3");
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

        void OnSceneLoaded(Scene scene, LoadSceneMode mode){
                if(pendingSettings != null){
                        GameObject obj = new GameObject("LevelSettings");
                        obj.AddComponent(pendingSettings);
                        pendingSettings = null;
                }
        }
}
