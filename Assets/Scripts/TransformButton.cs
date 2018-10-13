using UnityEngine;

public class TransformButton : MonoBehaviour {

    public GameObject transformationResult;

    public void Transform() {
        GameObject gameObject = Object.Instantiate(transformationResult);
        Transform transform = TransformGun.currentTarget.transform;
        gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        Destroy(TransformGun.currentTarget);
    }
}
