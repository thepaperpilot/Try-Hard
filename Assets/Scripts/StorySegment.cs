using System.Collections;
using UnityEngine;

public class StorySegment : MonoBehaviour {

    public Dialogue[] story;

    void Start() {
        StartCoroutine(PlayStory());
    }

    IEnumerator PlayStory() {
        for (int i = 0; i < story.Length; i++) {
            Dialogue dialogue = story[i];
            // Keep trying to play the dialogue until it plays
            while (!DialogueManager.instance.PlayDialogue(dialogue))
                yield return new WaitForEndOfFrame();
            // Wait for length of that dialogue before moving on
            yield return new WaitForSeconds(dialogue.voice.length + DialogueManager.instance.delayBetweenDialogues);
        }
    }
}
