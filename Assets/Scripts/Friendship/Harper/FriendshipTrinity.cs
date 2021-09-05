using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FriendshipTrinity : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject dialogueOnWhichToGetSurprised = null;
    [SerializeField] int sentenceOnWhichToGetSurprised = 0;
    [SerializeField] float timeBeforeSurprise = 1.0f;

    [SerializeField] GameObject dialogueOnWhichToLeave = null;
    [SerializeField] int sentenceOnWhichToLeave = 5;
    [SerializeField] Transform exitDestination = null;

    private NavMeshAgent navmeshAgent;
    private Animator animator;
    private bool wasSurprised = false;
    private bool isOver = false;

    private void Awake()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        navmeshAgent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        StopIfDestinationReached();
        GetSurprisedAtTheRightMoment();
        LeaveWhenAllIsOver();
    }

    private void LeaveWhenAllIsOver()
    {
        if (isOver || !dialogueOnWhichToLeave.activeInHierarchy) return;

        var dialogueManager = dialogueOnWhichToLeave.GetComponent<FriendshipDialogueManager>();

        if (dialogueManager.GetCurrentSentence() == sentenceOnWhichToLeave)
        {
            isOver = true;
            navmeshAgent.SetDestination(exitDestination.position);
            navmeshAgent.isStopped = false;
            animator.SetTrigger("isLeaving");

            Destroy(gameObject, 5.0f);
        }
    }

    private void GetSurprisedAtTheRightMoment()
    {
        if (wasSurprised || !dialogueOnWhichToGetSurprised.activeInHierarchy) return;
        
        var dialogueManager = dialogueOnWhichToGetSurprised.GetComponent<FriendshipDialogueManager>();

        if (dialogueManager.GetCurrentSentence() == sentenceOnWhichToGetSurprised)
        {
            wasSurprised = true;
            StartCoroutine(GetSurprised());
        }
    }

    private IEnumerator GetSurprised()
    {
        yield return new WaitForSeconds(timeBeforeSurprise);
        animator.SetTrigger("isSurprised");
    }

    private void StopIfDestinationReached()
    {
        if (navmeshAgent.isStopped) return;
        if (isOver) return;

        if (navmeshAgent.remainingDistance <= navmeshAgent.stoppingDistance)
        {
            if (!navmeshAgent.hasPath || navmeshAgent.velocity.sqrMagnitude == 0f)
            {
                navmeshAgent.isStopped = true;
                animator.SetTrigger("isArrived");
            }
        }
    }
}
