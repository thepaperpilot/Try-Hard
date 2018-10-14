using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string preload;

    AsyncOperation operation;

    void Start() {
        if (preload != null) {
            operation = SceneManager.LoadSceneAsync(preload);
            operation.allowSceneActivation = false;
        }
    }

    public void ChangeScene(string name) {
        if (name == preload) {
            operation.allowSceneActivation = true;
        } else {
            SceneManager.LoadScene(name);
        }
    }
}
