using UnityEngine;

public class TurnObjectOnWhenStarting : MonoBehaviour
{
    public GameObject ToTurnOn;
    GameObject toTurnOn2;

    public bool isTurnoff;
    public GameObject TurnOffOnStart;
    public GameObject toTurnOnDelay;
    [SerializeField] int sentenceOnWhichToTurnOnGameObject = 0;

    void Start()
    {
        if (isTurnoff)
        {
            TurnOffOnStart?.SetActive(false);
        }

        else
        {
            ToTurnOn?.SetActive(true);
        }
    }

    public void ToStartLater()
    {
        toTurnOnDelay?.SetActive(true);
      // ToTurnOn.SetActive(true);
    }

    public bool IsStartingLate()
    {
        return sentenceOnWhichToTurnOnGameObject > 0;
    }

    public int GetStartingSentence()
    {
        return sentenceOnWhichToTurnOnGameObject;
    }
}
