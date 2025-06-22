using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
//using static System.Net.Mime.MediaTypeNames;
//using System.Diagnostics;

public class LevelManager : MonoBehaviour
{
    public static Type pendingSettings;

    UnityEngine.AsyncOperation ao;
    public UnityEngine.UI.Text loadingText;
    public Button startButton;

    private GUIStyle yellowButtonStyle;


    void Awake()
    {
        if (startButton != null)
            startButton.gameObject.SetActive(false);
    }

    void Start()
    {
        // Setup yellow button style
        yellowButtonStyle = new GUIStyle(GUI.skin.button);
        yellowButtonStyle.fontSize = 16;
        yellowButtonStyle.fontStyle = FontStyle.Bold;
        yellowButtonStyle.normal.textColor = Color.black;

        Texture2D yellowTexture = new Texture2D(1, 1);
        yellowTexture.SetPixel(0, 0, Color.yellow);
        yellowTexture.Apply();

        yellowButtonStyle.normal.background = yellowTexture;
        yellowButtonStyle.hover.background = yellowTexture;
        yellowButtonStyle.active.background = yellowTexture;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Loaded Level: " + name);
        if (name == "Level1") pendingSettings = typeof(Level1Settings);
        else if (name == "Level2") pendingSettings = typeof(Level2Settings);

        SceneManager.LoadScene(name);
    }

    public void QuitLevel()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            string nextName = SceneManager.GetSceneByBuildIndex(nextIndex).name;
            if (nextName == "Level2") pendingSettings = typeof(Level2Settings);
            else pendingSettings = null;

            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            // SAFELY initialize the style only once
            if (yellowButtonStyle == null)
            {
                yellowButtonStyle = new GUIStyle(GUI.skin.button);
                yellowButtonStyle.fontSize = 16;
                yellowButtonStyle.fontStyle = FontStyle.Bold;
                yellowButtonStyle.normal.textColor = Color.black;

                // Create yellow texture
                Texture2D yellowTexture = new Texture2D(1, 1);
                yellowTexture.SetPixel(0, 0, Color.yellow);
                yellowTexture.Apply();

                yellowButtonStyle.normal.background = yellowTexture;
                yellowButtonStyle.hover.background = yellowTexture;
                yellowButtonStyle.active.background = yellowTexture;
            }

            int width = 200;
            int height = 40;
            float x = Screen.width / 2 - width / 2;
            float y = Screen.height / 2 - height;

            if (GUI.Button(new Rect(x, y, width, height), "Level 1", yellowButtonStyle))
            {
                LoadLevel("Level1");
            }

            if (GUI.Button(new Rect(x, y + 50, width, height), "Level 2", yellowButtonStyle))
            {
                LoadLevel("Level2");
            }
        }
    }

    public void loadingGame()
    {
        if (startButton != null)
            startButton.gameObject.SetActive(false);

        if (loadingText != null)
            loadingText.gameObject.SetActive(true);

        StartCoroutine(loadGameWithProgress());
    }

    IEnumerator loadGameWithProgress()
    {
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            Debug.Log("Loading ...");

            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (pendingSettings != null)
        {
            GameObject obj = new GameObject("LevelSettings");
            obj.AddComponent(pendingSettings);
            pendingSettings = null;
        }
    }
}
