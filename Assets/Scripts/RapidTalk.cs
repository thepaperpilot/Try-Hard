using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RapidTalk : MonoBehaviour {

    public Sprite[] frames;
    public float durationBetweenFrames;

    float delta = 0;
    int frame = 0;
    Image image;

    void Awake() {
        image = GetComponent<Image>();
    }

    void Start() {
        image.sprite = frames[0];
    }

    void Update() {
        delta += Time.fixedUnscaledTime;
        if (delta >= durationBetweenFrames) {
            delta -= durationBetweenFrames;
            frame++;
            if (frame == frames.Length)
                frame = 0;
            image.sprite = frames[frame];
        }
    }
}
