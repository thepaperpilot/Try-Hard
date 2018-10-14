using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunPickup : MonoBehaviour {
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer == 9) {
            TransformGun.instance.gunAquired = true;
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            Destroy(gameObject, audio.clip.length);
        }
    }
}
