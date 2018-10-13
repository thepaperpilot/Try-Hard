using UnityEngine;
using UnityEngine.EventSystems;

public class TransformButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject transformationResult;

    public void OnPointerEnter(PointerEventData eventData) {
        GameObject gameObject = Object.Instantiate(transformationResult);
        Transform transform = TransformGun.currentTarget.transform;
        gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        if (TransformGun.currentTarget == TransformGun.originalTarget)
            TransformGun.currentTarget.SetActive(false);
        else
            Destroy(TransformGun.currentTarget);
        TransformGun.currentTarget = gameObject;
        Poof();
    }

    public void OnPointerExit(PointerEventData eventData) {
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
