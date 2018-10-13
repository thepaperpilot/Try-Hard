using UnityEngine;

public class TransformGun : MonoBehaviour {

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            // We right clicked, lets see if we should open the transform menu
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.yellow, 1);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
                // We hit something!
                if (hit.transform.CompareTag("transformable")) {
                    // We hit something transformable
                    // Finally we can actually do something!
                    TransformMenu.instance.gameObject.SetActive(true);
                }
            }
        }
        if (Input.GetMouseButtonUp(1)) {
            TransformMenu.instance.gameObject.SetActive(false);
        }
    }
}
