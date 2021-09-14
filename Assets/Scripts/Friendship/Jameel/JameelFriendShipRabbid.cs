using UnityEngine;
using UnityEngine.AI;

public class JameelFriendShipRabbid : MonoBehaviour
{
    [SerializeField] Transform destination = null;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
