using UnityEngine;
using TMPro;
using System;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour {

    public static DialogueManager instance = null;

    public RapidTalk portrait;
    public TextMeshProUGUI text;
    public float delayBetweenDialogues;

    AudioSource source;
    bool ready = true;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        source = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    public bool PlayDialogue(Dialogue dialogue) {
        if (!ready) {
            // Don't play the dialogue, and tell whoever called us we didn't do it
            return false;
        }
        // Set up dialogue
        gameObject.SetActive(true);
        ready = false;
        portrait.enabled = true;
        if (dialogue.portrait)
            portrait.frames = dialogue.portrait.frames;
        text.text = dialogue.text;
        source.PlayOneShot(dialogue.voice);

        // Wait until the audio clip finished
        StartCoroutine(Delay(dialogue.voice.length, () => {
            portrait.enabled = false;
            // And then wait some time before being ready for the next dialogue to show
            StartCoroutine(Delay(delayBetweenDialogues, () => {
                gameObject.SetActive(false);
                ready = true;
            }));
        }));
        return true;
    }
    
    IEnumerator Delay(float seconds, Action callback) {
        yield return new WaitForSecondsRealtime(seconds);
        callback();
    }
}
