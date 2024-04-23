using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindFirstObjectByType<DialougeManager>().StartDialogue(dialogue);
    }
}
