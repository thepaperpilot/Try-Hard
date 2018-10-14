using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Grunt : MonoBehaviour {

    public Dialogue[] onSee;

    NavMeshAgent agent;
    AudioSource source;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
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
            source.Play();
            Time.timeScale = 0;
            collider.gameObject.GetComponentInChildren<TransformGun>().deathParticles.SetActive(true);
        }
    }
}
