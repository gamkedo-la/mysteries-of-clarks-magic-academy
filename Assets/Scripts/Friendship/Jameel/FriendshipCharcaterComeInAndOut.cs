using UnityEngine;
using UnityEngine.AI;

public class FriendshipCharcaterComeInAndOut : MonoBehaviour
{
    [SerializeField] Transform enterDestination = null;
    [SerializeField] Transform exitDestination = null;
    [SerializeField] FriendshipDialogueManager dialogueToEnterScene = null;
    [SerializeField] FriendshipDialogueManager dialogueToExitScene = null;
    [SerializeField] Transform lookAt = null;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool isEnteringScene = true;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        EnterTheSceneAtCorrectDialogue();

        if (isEnteringScene)
        {
            StopIfDestinationReached();
            transform.LookAt(lookAt);
        }

        ExitTheSceneAtCorrectDialogue();
    }

    private void EnterTheSceneAtCorrectDialogue()
    {
        if (dialogueToEnterScene.isActiveAndEnabled && navMeshAgent.isStopped)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(enterDestination.position);

            animator.SetBool("isWalking", true);
            isEnteringScene = true;
        }
    }

    private void ExitTheSceneAtCorrectDialogue()
    {
        if (dialogueToExitScene.isActiveAndEnabled && navMeshAgent.isStopped)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(exitDestination.position);

            animator.SetBool("isWalking", true);
            Destroy(gameObject, 10.0f);
        }
    }

    private void StopIfDestinationReached()
    {
        if (navMeshAgent.isStopped) return;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                navMeshAgent.isStopped = true;
                animator.SetBool("isWalking", false);
                isEnteringScene = false;
            }
        }
    }
}
