using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Vector3 respawnPoint;

    void OnTriggerEnter(Collider other) {
        RestartManager.instance.SetRespawnPoint(respawnPoint);
    }
}
