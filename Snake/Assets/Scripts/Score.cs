using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        score = FruitRotator.count;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        // Bold and dynamic scaling
        style.fontSize = Mathf.RoundToInt(Screen.height * 0.03f);
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;

        string scoreText = "Score: " + score;

        Vector2 size = style.CalcSize(new GUIContent(scoreText));
        float x = (Screen.width - size.x) / 2f;
        float y = Screen.height * 0.02f;

        GUI.Label(new Rect(x, y, size.x, size.y), scoreText, style);
    }
}
