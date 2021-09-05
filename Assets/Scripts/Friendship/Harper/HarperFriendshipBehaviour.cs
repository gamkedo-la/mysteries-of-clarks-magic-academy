using UnityEngine;

public class HarperFriendshipBehaviour : MonoBehaviour
{
    [SerializeField] GameObject dialogueOnWhichToFaceTrinity = null;
    [SerializeField] int sentenceOnWhichToFaceTrinity = 0;
    [SerializeField] bool isTrinityScene = false;
    [SerializeField] Transform trinityLocation = null;
    
    [SerializeField] GameObject dialogueOnWhichToFaceMC = null;
    [SerializeField] int sentenceOnWhichToFaceMC = 0;
    [SerializeField] float speedToRotate = 10.0f;


    private bool isFacingTrinity = false;
    private bool isTurningToFaceTrinity = false;

    private bool isFacingMC = true;
    private bool isTurningToFaceMC = false;

    private Vector3 initialOrientation;

    private void Start()
    {
        isFacingTrinity = false;
        isTurningToFaceTrinity = false;
        isFacingMC = true;
        isTurningToFaceMC = false;
        initialOrientation = transform.forward;
    }

    private void Update()
    {
        TurnToTrinityAtTheRightMoment();
        TurnToMCAtTheRightMoment();
    }

    private void TurnToMCAtTheRightMoment()
    {
        if (!isTrinityScene) return;
        if (isFacingMC || !dialogueOnWhichToFaceMC.activeInHierarchy) return;
        
        if (!isTurningToFaceMC)
        {
            var dialogueManager = dialogueOnWhichToFaceMC.GetComponent<FriendshipDialogueManager>();

            if (dialogueManager.GetCurrentSentence() == sentenceOnWhichToFaceMC)
            {
                isTurningToFaceMC = true;
            }
        }
        else
        {
            Vector3 targetDirection = trinityLocation.position - transform.position;
            TurnTowards(initialOrientation);

            if (Vector3.Angle(initialOrientation, transform.forward) < 0.01f)
            {
                isFacingMC = true;
                isTurningToFaceMC = false;
            }
        }
    }

    private void TurnToTrinityAtTheRightMoment()
    {
        if (!isTrinityScene) return;
        if (isFacingTrinity || !dialogueOnWhichToFaceTrinity.activeInHierarchy) return;
        
        if (!isTurningToFaceTrinity)
        {
            var dialogueManager = dialogueOnWhichToFaceTrinity.GetComponent<FriendshipDialogueManager>();

            if (dialogueManager.GetCurrentSentence() == sentenceOnWhichToFaceTrinity)
            {
                isTurningToFaceTrinity = true;
                isFacingMC = false;
            }
        }
        else
        {
            Vector3 targetDirection = trinityLocation.position - transform.position;
            TurnTowards(targetDirection);

            if (Vector3.Angle(targetDirection, transform.forward) < 0.01f)
            {
                isFacingTrinity = true;
                isTurningToFaceTrinity = false;
            }
        }
    }

    private void TurnTowards(Vector3 targetDirection)
    {
        // Determine which direction to rotate towards

        // The step size is equal to speed times frame time.
        float singleStep = speedToRotate * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
