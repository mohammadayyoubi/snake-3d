using UnityEngine;

public class Level2Settings : MonoBehaviour {
    void Start() {
        Apply();
    }

    public void Apply() {
        TestMovement tm = FindObjectOfType<TestMovement>();
        if (tm != null) {
            tm.noOfEnemies = 1;
            tm.noOfRocks = 4;
            tm.speed = 1.0f;
        }
    }
}
