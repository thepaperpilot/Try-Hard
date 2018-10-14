using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bomb : MonoBehaviour {

    public float range = 8;
    public GameObject blowup;

    AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    void Ignite() {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Enemy").Where(enemy => Vector3.Distance(enemy.transform.position, TransformGun.instance.transform.parent.position) <= range)) {
            gameObject.SendMessage("Die");
        }
        blowup.SetActive(true);
        Destroy(gameObject, 2);
        source.Play();
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(GetComponent<BoxCollider>());
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
            Destroy(mr);
    }
}
