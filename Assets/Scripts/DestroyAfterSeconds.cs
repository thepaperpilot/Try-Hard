using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    public float duration;

	void Start () {
        Destroy(gameObject, duration);
	}

    void OnDisable() {
        Destroy(gameObject);
    }
}
