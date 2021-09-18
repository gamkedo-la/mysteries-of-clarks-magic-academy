using UnityEngine;
using UnityEngine.AI;

public class FriendshipCharcaterComeInAndOut : MonoBehaviour
{
    [SerializeField] Transform enterDestination = null;
    [SerializeField] Transform exitDestination = null;
    [SerializeField] FriendshipDialogueManager dialogueToEnterScene = null;
    [SerializeField] FriendshipDialogueManager dialogueToExitScene = null;
    [SerializeField] Transform lookAt = null;

    [Header("Specific to moment 3-4")]
    [SerializeField] FriendshipDialogueManager dialogueToSitDown = null;
    [SerializeField] Transform sittingLocation = null;
    [SerializeField] Transform chair = null;
    [SerializeField] Transform chairLocationWhenSitting = null;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool isEnteringScene = false;
    private bool isSittingDown = false;
    private bool isSitting = false;

    private float sittingSpeed = 1.0f;
    // private float is

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.isStopped = true;
        animator.ResetTrigger("sitDown");
    }

    // Update is called once per frame
    void Update()
    {
        EnterTheSceneAtCorrectDialogue();

        if (isEnteringScene)
        {
            StopIfDestinationReached();
        }

        SitDownIfNeeded();

        ExitTheSceneAtCorrectDialogue();
    }

    private void SitDownIfNeeded()
    {
        if (dialogueToSitDown == null) return;
        TriggerSitDownAnimation();
        GoToSittingLocation();
    }

    private void GoToSittingLocation()
    {
        if (!isSittingDown) return;
        if (isSitting) return;

        transform.position = Vector3.MoveTowards(transform.position,
                                                 sittingLocation.position,
                                                 sittingSpeed*Time.deltaTime);
        
        if (chair != null)
        {
            chair.position = Vector3.MoveTowards(chair.position,
                                                chairLocationWhenSitting.position,
                                                sittingSpeed*Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, sittingLocation.position) < 1.0e-5 && 
            (chair == null || Vector3.Distance(chair.position, chairLocationWhenSitting.position) < 1.0e-5 ))
        {
            isSitting = true;
        }
    }

    private void TriggerSitDownAnimation()
    {
        if (isSittingDown) return;
        if (!dialogueToSitDown.isActiveAndEnabled) return;

        animator.SetTrigger("sitDown");
        isSittingDown = true;
        navMeshAgent.enabled = false;
    }

    private void EnterTheSceneAtCorrectDialogue()
    {
        if (isEnteringScene) return;

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
        if (dialogueToExitScene.isActiveAndEnabled)
        {
            if (!navMeshAgent.enabled) navMeshAgent.enabled = true;
            if (navMeshAgent.isStopped) navMeshAgent.isStopped = false;

            if (!animator.GetBool("isWalking"))
            {
                animator.SetBool("isWalking", true);
                navMeshAgent.SetDestination(exitDestination.position);
                Destroy(gameObject, 10.0f);
            }
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
                
                transform.LookAt(lookAt);
            }
        }
    }
}
