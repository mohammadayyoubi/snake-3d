using UnityEngine;

public class Level1Settings : MonoBehaviour {
    void Start() {
        Apply();
    }

    public void Apply() {
        TestMovement tm = FindObjectOfType<TestMovement>();
        if (tm != null) {
            tm.noOfEnemies = 0;
            tm.noOfRocks = 5;
            tm.speed = 1.0f;
        }
    }
}

