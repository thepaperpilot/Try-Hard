using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TransformButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject transformationResult;

    void Start() {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.01f;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        GameObject gameObject = Object.Instantiate(transformationResult);
        TransformGun.UpdateOutline(gameObject.transform, 0.025f);
        Transform transform = TransformGun.currentTarget.transform;
        gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        gameObject.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity;
        gameObject.GetComponent<TransformableObject>().isThrown = transform.GetComponent<TransformableObject>().isThrown;
        if (TransformGun.currentTarget == TransformGun.originalTarget)
            TransformGun.currentTarget.SetActive(false);
        else
            Destroy(TransformGun.currentTarget);
        TransformGun.currentTarget = gameObject;
        Poof();
    }

    public void OnPointerExit(PointerEventData eventData) {
        TransformGun.originalTarget.transform.SetPositionAndRotation(TransformGun.currentTarget.transform.position, TransformGun.currentTarget.transform.rotation);
        TransformGun.originalTarget.GetComponent<Rigidbody>().velocity = TransformGun.currentTarget.GetComponent<Rigidbody>().velocity;
        TransformGun.originalTarget.GetComponent<TransformableObject>().isThrown = TransformGun.currentTarget.GetComponent<TransformableObject>().isThrown;
        Destroy(TransformGun.currentTarget);
        TransformGun.originalTarget.SetActive(true);
        TransformGun.currentTarget = TransformGun.originalTarget;
        Poof();
    }

    void Poof() {
        Object.Instantiate(TransformMenu.instance.poof, TransformGun.currentTarget.transform);
        TransformMenu.instance.poofSound.Play();
    }
}
