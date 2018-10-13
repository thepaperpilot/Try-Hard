using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    public Transform head;

    float walkSpeed = 5;
    float jumpPower = 6;

    public bool lockMouse = true;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(GetWalkDirection() * walkSpeed);
	}

    Vector3 GetWalkDirection()
    {
        Vector2 dir = (transform.forward * Input.GetAxis("Horizontal") + transform.right * Input.GetAxis("Vertical")).normalized;
        return new Vector3(dir.x, 0, dir.y);
    }
}
