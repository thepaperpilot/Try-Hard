using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TransformMenu : MonoBehaviour {

    public static TransformMenu instance = null;

    public GameObject poof;

    [HideInInspector]
    public AudioSource poofSound;
    
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        poofSound = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }
}
