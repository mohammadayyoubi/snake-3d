using UnityEngine;

public class Level3Settings : MonoBehaviour {
    void Start() {
        Apply();
    }

    public void Apply() {
        TestMovement tm = FindObjectOfType<TestMovement>();
        if (tm != null) {
            tm.noOfEnemies = 3;
            tm.noOfRocks = 10;
            tm.speed = 1.5f;
        }
    }
}
