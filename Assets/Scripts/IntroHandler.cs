using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class IntroHandler : MonoBehaviour {

    public StorySegment intro1;
    public StorySegment intro2;
    public StorySegment tutorial1;

    FirstPersonController fps;
    AudioSource audio;

    void Awake() {
        if (RestartManager.instance && RestartManager.instance.introSeen) {
            Destroy(gameObject);
            return;
        }

        intro1.enabled = false;
        intro2.enabled = false;
        tutorial1.enabled = false;

        fps = GetComponentInParent<FirstPersonController>();
        audio = GetComponentInParent<AudioSource>();
        audio.enabled = false;
        StartCoroutine(DelayDisableFPS());
    }

    void PlayIntroOne() {
        intro1.enabled = true;
    }

    void PlayIntroTwo() {
        intro2.enabled = true;
    }

    void AllowMovement() {
        fps.enabled = true;
        audio.enabled = true;
    }

    void PlayTutorialOne() {
        tutorial1.enabled = true;
        RestartManager.instance.introSeen = true;
        Destroy(gameObject, 5);
    }

    IEnumerator DelayDisableFPS() {
        // We do this so its little initial jitter will happen during the black screen
        yield return null;
        fps.enabled = false;
    }
}
