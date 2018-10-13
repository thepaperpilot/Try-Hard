﻿using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TransformGun : MonoBehaviour {

    public static TransformGun instance;
    public static GameObject currentTarget;
    public static GameObject originalTarget;

    public EventSystem eventSystem;
    public GraphicRaycaster graphicRaycaster;
    public FirstPersonController fps;
    public float bulletTimeSpeed = 0.2f;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            // We right clicked, lets see if we should open the transform menu
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.yellow, 1);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, ~(1 << 9))) {
                // We hit something!
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("transformable")) {
                    // We hit something transformable
                    // Finally we can actually do something!
                    originalTarget = currentTarget = hit.transform.gameObject;
                    UpdateOutline(originalTarget.transform, 0.025f);
                    TransformMenu.instance.gameObject.SetActive(true);
                    Time.timeScale = bulletTimeSpeed;
                    fps.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(1)) {
            // Reset everything
            if (currentTarget)
                UpdateOutline(currentTarget.transform, 0);
            if (originalTarget != currentTarget)
                Destroy(originalTarget);
            originalTarget = currentTarget = null;
            TransformMenu.instance.gameObject.SetActive(false);
            Time.timeScale = 1;
            fps.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public static void UpdateOutline(Transform transform, float width) {
        foreach (MeshRenderer r in transform.GetComponentsInChildren<MeshRenderer>()) {
            Debug.Log(r.transform.lossyScale);
            r.material.SetFloat("_FirstOutlineWidth", width / r.transform.lossyScale.x);
        }
    }
}
