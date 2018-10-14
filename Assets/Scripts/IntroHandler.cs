using UnityEngine;

public class IntroHandler : MonoBehaviour {

    public StorySegment intro1;
    public StorySegment intro2;
    public StorySegment tutorial1;
    public TransformGun player;

    void Awake() {
        if (RestartManager.instance && RestartManager.instance.introSeen) {
            Destroy(gameObject);
            player.gunAquired = false;
            return;
        }

        intro1.enabled = false;
        intro2.enabled = false;
        tutorial1.enabled = false;
    }

    void PlayIntroOne() {
        intro1.enabled = true;
    }

    void PlayIntroTwo() {
        intro2.enabled = true;
    }

    void PlayTutorialOne() {
        tutorial1.enabled = true;
    }
}
