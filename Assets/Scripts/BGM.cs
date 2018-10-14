using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

    public AudioSource rain;
    public AudioSource piano;

    void Start() {
        StartCoroutine(DelayBGM());
    }

    IEnumerator DelayBGM() {
        yield return new WaitForSecondsRealtime(10);
        for (float i = 0; i < 1; i += 4 * Time.deltaTime) {
            rain.volume = 1 - i / 2f;
            piano.volume = i / 2f;
            yield return null;
        }
    }
}
