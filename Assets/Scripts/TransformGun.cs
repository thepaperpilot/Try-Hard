using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TransformGun : MonoBehaviour {

    public static GameObject currentTarget;
    public static GameObject originalTarget;

    public EventSystem eventSystem;
    public GraphicRaycaster graphicRaycaster;
    public float bulletTimeSpeed = 0.2f;
    
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
                    originalTarget = currentTarget = hit.transform.gameObject;
                    TransformMenu.instance.gameObject.SetActive(true);
                    Time.timeScale = bulletTimeSpeed;
                }
            }
        }
        if (Input.GetMouseButtonUp(1)) {
            // Reset everything
            originalTarget = currentTarget = null;
            TransformMenu.instance.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
