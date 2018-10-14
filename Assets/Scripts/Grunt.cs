using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Grunt : MonoBehaviour {

    public Dialogue[] onSee;
    public AudioSource audio;
    public AudioClip[] deathSounds;

    NavMeshAgent agent;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, TransformGun.instance.transform.position - transform.position, out hit, Mathf.Infinity)) {
            if (hit.transform == TransformGun.instance.transform.parent) {
                // We see the player!
                if (agent.isStopped) {
                    // Oh, we *just* saw the player!
                    PlayDialogue(onSee);
                }
                agent.destination = TransformGun.instance.transform.parent.position;
                agent.isStopped = false;
                return;
            }
        }
        // If we get here, we didn't see the player
        agent.isStopped = true;
    }

    void PlayDialogue(Dialogue[] options) {
        if (options.Length > 0)
            DialogueManager.instance.PlayDialogue(options[Random.Range(0, options.Length)]);
    }

    void OnTriggerEnter(Collider collider) {
        // If colliding with player
        if (collider.gameObject.layer == 9) {
            audio.Play();
            Time.timeScale = 0;
            collider.gameObject.GetComponentInChildren<TransformGun>().deathParticles.SetActive(true);
        } else if (collider.gameObject.layer == 10) {
            Die();
        } else if (collider.gameObject.CompareTag("transformable")) {
            Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude > 0) {
                Die();
            }
        }
    }

    void Die() {
        AudioClip clip = deathSounds[Random.Range(0, deathSounds.Length)];
        audio.PlayOneShot(clip);
        Destroy(gameObject, clip.length);
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponent<MeshRenderer>());
    }
}
