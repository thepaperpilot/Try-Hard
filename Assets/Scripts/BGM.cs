using System.Collections;
using UnityEngine;

public class BGM : MonoBehaviour {

    public AudioSource rain;
    public AudioSource piano;

    void Start() {
        StartCoroutine(DelayBGM());
    }

    IEnumerator DelayBGM() {
        yield return new WaitForSecondsRealtime(3);
        for (float i = 0; i < 1; i += Time.deltaTime / 2f) {
            rain.volume = i;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(5);
        for (float i = 0; i < 1; i += 4 * Time.deltaTime) {
            rain.volume = 1 - i / 2f;
            piano.volume = i / 2f;
            yield return null;
        }
    }
}
