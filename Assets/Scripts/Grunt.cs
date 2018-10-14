using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Grunt : MonoBehaviour {

    public Dialogue[] onSee;
    public Dialogue[] deathSounds;
    public AudioSource audio;

    NavMeshAgent agent;
    Animator anim;

    public Animation idleAnimation, runAnimation;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
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
                anim.SetBool("isStopped", false);
                return;
            }
        }
        // If we get here, we didn't see the player
        agent.isStopped = true;
        anim.SetBool("isStopped", true);
    }

    float PlayDialogue(Dialogue[] options) {
        if (options.Length > 0) {
            Dialogue dialogue = options[Random.Range(0, options.Length)];
            DialogueManager.instance.PlayDialogue(dialogue);
            return dialogue.voice.length;
        }
        return 0;
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
        Destroy(gameObject, PlayDialogue(deathSounds));
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponent<MeshRenderer>());
    }
}
