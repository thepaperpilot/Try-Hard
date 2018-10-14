using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunPickup : MonoBehaviour {

    StorySegment story;

    void Awake() {
        story = gameObject.GetComponent<StorySegment>();
        story.enabled = false;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer == 9) {
            TransformGun.instance.gunAquired = true;
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            story.enabled = true;
        }
    }
}
