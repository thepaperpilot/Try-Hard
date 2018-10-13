using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TransformGun : MonoBehaviour {

    public static GameObject currentTarget;

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
                    currentTarget = hit.transform.gameObject;
                    TransformMenu.instance.gameObject.SetActive(true);
                    Time.timeScale = bulletTimeSpeed;
                }
            }
        }
        if (Input.GetMouseButtonUp(1)) {
            // Find out which (if any) button we were on when we lifted up
            PointerEventData data = new PointerEventData(eventSystem);
            data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            //Raycast using the Graphics Raycaster and mouse click position
            graphicRaycaster.Raycast(data, results);
            results.Any(r => {
                TransformButton button = r.gameObject.GetComponent<TransformButton>();
                // If its one of our buttons, transform our object!
                if (button) {
                    button.Transform();
                    return true;
                }
                return false;
            });

            // Reset everything
            currentTarget = null;
            TransformMenu.instance.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
