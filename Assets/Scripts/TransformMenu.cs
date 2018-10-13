using UnityEngine;

public class TransformMenu : MonoBehaviour {

    public static TransformMenu instance = null;
    
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        gameObject.SetActive(false);
    }
}
