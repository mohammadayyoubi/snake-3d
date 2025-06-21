using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
    public float speed = 1.0f;
    public float detectionRange = 10f;
    private Transform target;

    void Start() {
        GameObject head = GameObject.FindGameObjectWithTag("Head");
        if (head != null) {
            target = head.transform;
        }

        if (SceneManager.GetActiveScene().name == "Level1") {
            speed = 0f; // stationary rock on Level 1
        }
    }

    void Update() {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        // simple raycast in front to avoid walls or rocks
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f)) {
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Rock")) {
                transform.Rotate(0, Random.Range(90, 270), 0);
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 2f);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
