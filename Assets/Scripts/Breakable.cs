using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Breakable : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 10) {
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
