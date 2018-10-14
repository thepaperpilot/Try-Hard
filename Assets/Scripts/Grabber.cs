using UnityEngine;

public class Grabber : MonoBehaviour {

    public float pickupDistance = 5;
    public Transform heldItemContainer;
    public float throwStrength = 100;

    Transform heldItem = null;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (heldItem == null) {
                RaycastHit hit;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.green, 1);
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupDistance, 1 << 10)) {
                    // We hit something!
                    heldItem = hit.transform.GetComponentInParent<TransformableObject>().transform;
                    heldItem.gameObject.layer = 11;
                    heldItem.SetParent(heldItemContainer);
                    heldItem.localPosition = Vector3.zero;
                    heldItem.GetComponent<Rigidbody>().isKinematic = true;
                }
            } else {
                heldItem.SetParent(null);
                heldItem.gameObject.layer = 10;
                Rigidbody rb = heldItem.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(transform.TransformDirection(Vector3.forward) * throwStrength);
                heldItem = null;
            }
        }
    }
}
