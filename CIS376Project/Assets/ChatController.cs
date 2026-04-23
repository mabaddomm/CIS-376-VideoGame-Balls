using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ChatController : MonoBehaviour
{
    enum State { WALKING, CHASING }

    [SerializeField] private GameObject[] locations;
    [SerializeField] private int health = 10;
    
    private NavMeshAgent nav;
    private GameObject player;
    private Animator animator;
    private int currentLocation = 0;
    private State state = State.WALKING;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");

        locations = new GameObject[] {
            GameObject.Find("TargetOne"),
            GameObject.Find("TargetTwo"),
            GameObject.Find("TargetThree"),
        };
        nav.SetDestination(locations[0].transform.position);
        SetState(State.WALKING, "Walk");
    }

//Helps with animations and chaning state
    void SetState(State newState, string animation = null)
    {
        state = newState;
        if (animation != null) animator.Play(animation);
        Debug.Log(state);
    }


    void StartChasing()
    {
        if (state == State.CHASING) return;
        SetState(State.CHASING, "Run");
    }

    void StartWalking()
    {
        SetState(State.WALKING, "Walk");
        nav.speed = 3.5f;
        nav.SetDestination(locations[currentLocation].transform.position);

    }

    void UpdateChasing() {
        nav.isStopped = false;
        nav.SetDestination(player.transform.position);
        nav.speed = 7f;
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 5f) {
            StartChasing();
        }
        else if (distance > 10f) {
            StartWalking();
        }

        if (state == State.WALKING && nav.remainingDistance < 0.6f){
            nav.SetDestination(locations[++currentLocation % locations.Length].transform.position);
        }
    
        // Go after them!
        if (state == State.CHASING) {
            UpdateChasing();
        }
    }
    


}
