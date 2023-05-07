using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PirateBattle : MonoBehaviour
{
    public NPCConversation PirateConversation;
    private void OnMouseOver()
    {
        ConversationManager.Instance.StartConversation(PirateConversation);
    }
}
