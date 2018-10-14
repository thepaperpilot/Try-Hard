using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(StorySegment))]
public class RestartManager : MonoBehaviour {

    public static RestartManager instance = null;

    [SerializeField]
    Vector3 startPos;
    StorySegment story;
    public bool introSeen;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        story = GetComponent<StorySegment>();
        story.enabled = false;
    }

    void Start() {
        SceneManager.sceneLoaded += LoadPlayer;
    }

    void LoadPlayer(Scene scene, LoadSceneMode mode) {
        TransformGun.instance.transform.parent.position = startPos;
        story.enabled = false;
        story.enabled = true;
        Time.timeScale = 1;
    }

    public void SetRespawnPoint(Vector3 start) {
        this.startPos = start;
    }
}
