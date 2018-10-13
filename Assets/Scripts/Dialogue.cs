using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject {

    public Portrait portrait;
    [TextArea]
    public string text;
    public AudioClip voice;
}
