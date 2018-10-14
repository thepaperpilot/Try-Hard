using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Title");
    }
}
