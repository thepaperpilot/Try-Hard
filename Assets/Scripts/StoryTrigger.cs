using UnityEngine;

[RequireComponent(typeof(StorySegment))]
public class StoryTrigger : MonoBehaviour {

    StorySegment story;

    void Awake() {
        story = GetComponent<StorySegment>();
        story.enabled = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9) {
            story.enabled = true;
            Destroy(this);
        }
    }
}
