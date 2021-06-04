using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendConversationChoice : MonoBehaviour
{
    public bool AcceptConversation, DeclineConversation;
    public GameObject AcceptConversationDialogue, DeclineConversationDialogue;
    public GameObject choiceGameObject;
    public void ConversationButton()
    {
        if (AcceptConversation)
        {
            GameManager.isInFriendConversation = true;
            AcceptConversationDialogue.SetActive(true);
            choiceGameObject.SetActive(false);
        }

        if (DeclineConversation)
        {
            GameManager.isInFriendConversation = false;
            DeclineConversationDialogue.SetActive(true);
            choiceGameObject.SetActive(false);
        }
    }
}
