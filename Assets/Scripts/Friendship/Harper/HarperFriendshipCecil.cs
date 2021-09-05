using UnityEngine;
using UnityEngine.AI;

public class HarperFriendshipCecil : MonoBehaviour
{
    [SerializeField] Transform destination = null;
    [SerializeField] int sentenceOnWhichToLeave = 0;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 initalPosition;
    private FriendshipDialogueManager dialogueManager;
    private bool isOver = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
        navMeshAgent.SetDestination(destination.position);
        dialogueManager = FindObjectOfType<FriendshipDialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StopsWhenIsArrived();
        LeavesWhenAllIsDone();
    }

    private void LeavesWhenAllIsDone()
    {
        if (isOver) return;
        
        if (dialogueManager.GetCurrentSentence() == sentenceOnWhichToLeave)
        {
            animator.SetTrigger("isLeaving");
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(initalPosition);
            isOver = true;
            Destroy(gameObject, 5.0f);
        }
    }

    private void StopsWhenIsArrived()
    {
        if (navMeshAgent.isStopped || isOver) return;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                navMeshAgent.isStopped = true;
                animator.SetTrigger("isArrived");
            }
        }
    }

    
}
