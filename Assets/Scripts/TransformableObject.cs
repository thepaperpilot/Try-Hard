using UnityEngine;

public class TransformableObject : MonoBehaviour {

    public bool isThrown = false;

    void OnCollisionEnter(Collision collision) {
        if (isThrown) SendMessage("Ignite");
        isThrown = false;
    }
}
