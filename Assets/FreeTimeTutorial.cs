using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeTimeTutorial : MonoBehaviour
{
    [TextArea(1,1)]
    public string Title = "Tutorial";
    
    [TextArea(10,10)]
    public string TXT1 = "Page one text.\nThe rest are optional.";
    [TextArea(10,10)]
    public string TXT2 = "";
    [TextArea(10,10)]
    public string TXT3 = "";
    
    public GameObject FirstScreen, SecondScreen, ThirdScreen;

    public bool SecondTutorial;
    public bool DungeonTutorial;
    public bool BattleTutorial;

    public void Start()
    {
        if (GameManager.secondFloorTutorial && SecondTutorial)
        {
            this.gameObject.SetActive(false);
        }

        if (GameManager.dungeonTutorial && DungeonTutorial)
        {
            this.gameObject.SetActive(false);
        }

        if (GameManager.battleTutorial && BattleTutorial)
        {
            this.gameObject.SetActive(false);
        }
        // assign custom texts *if* we have set them
        if (TXT1!="") FirstScreen.transform.Find("TXT").GetComponent<Text>().text = TXT1;
        if (Title!="") FirstScreen.transform.Find("Title").GetComponent<Text>().text = Title;
        if (TXT2!="") SecondScreen.transform.Find("TXT").GetComponent<Text>().text = TXT2;
        if (Title!="") SecondScreen.transform.Find("Title").GetComponent<Text>().text = Title;
        if (TXT3!="") ThirdScreen.transform.Find("TXT").GetComponent<Text>().text = TXT3;
        if (Title!="") ThirdScreen.transform.Find("Title").GetComponent<Text>().text = Title;

        if (!GameManager.secondFloorTutorial && SecondTutorial)
        {
            Debug.Log("Showing tutorial screen 1");
            FirstScreen.SetActive(true);
        }

        if (!GameManager.dungeonTutorial && DungeonTutorial)
        {
            Debug.Log("Showing tutorial screen 1");
            FirstScreen.SetActive(true);
        }

        if (!GameManager.battleTutorial && BattleTutorial)
        {
            Debug.Log("Showing tutorial screen 1");
            FirstScreen.SetActive(true);
        }
    }

    public void FirstNextSecond()
    {
        if (TXT2!="") {
            Debug.Log("Showing tutorial screen 2");
            SecondScreen.SetActive(true); 
        }
        else {
            Debug.Log("Tutorial complete.");
            if (!GameManager.secondFloorTutorial && SecondTutorial)
            {
                GameManager.secondFloorTutorial = true;
            }

            if (!GameManager.dungeonTutorial && DungeonTutorial)
            {
                GameManager.dungeonTutorial = true;
            }

            if (!GameManager.battleTutorial && BattleTutorial)
            {
                GameManager.battleTutorial = true;
            }
        }

        FirstScreen.SetActive(false);
    }

    public void SecondNextThird()
    {
        if (TXT3!="") {
            Debug.Log("Showing tutorial screen 3");
            ThirdScreen.SetActive(true); 
        }
        else {
            Debug.Log("Tutorial complete.");
            if (!GameManager.secondFloorTutorial && SecondTutorial)
            {
                GameManager.secondFloorTutorial = true;
            }

            if (!GameManager.dungeonTutorial && DungeonTutorial)
            {
                GameManager.dungeonTutorial = true;
            }

            if (!GameManager.battleTutorial && BattleTutorial)
            {
                GameManager.battleTutorial = true;
            }
        }
        SecondScreen.SetActive(false);
    }

    public void Third()
    {
        Debug.Log("Tutorial complete.");
        if (!GameManager.secondFloorTutorial && SecondTutorial)
        {
            GameManager.secondFloorTutorial = true;
        }

        if (!GameManager.dungeonTutorial && DungeonTutorial)
        {
            GameManager.dungeonTutorial = true;
        }

        if (!GameManager.battleTutorial && BattleTutorial)
        {
            GameManager.battleTutorial = true;
        }
        ThirdScreen.SetActive(false);
    }
}
