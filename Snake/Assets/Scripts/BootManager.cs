using UnityEngine;
using UnityEngine.SceneManagement;

public static class BootManager {
    static bool initialized = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void EnsureStartLoaded() {
        if (initialized) return;
        initialized = true;
        Scene active = SceneManager.GetActiveScene();
        if (active.name != "Start") {
            SceneManager.LoadScene("Start");
        }
    }
}
