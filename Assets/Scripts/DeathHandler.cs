using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(StorySegment))]
public class DeathHandler : MonoBehaviour {

    StorySegment story;

    void Awake() {
        story = GetComponent<StorySegment>();
        story.enabled = false;
    }

    public void StartStory() {
        story.enabled = true;
    }

    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
