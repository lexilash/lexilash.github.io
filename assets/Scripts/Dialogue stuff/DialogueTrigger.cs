using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class DialogueCharacter // in case we want multiple characters to talk
{
    public string name;
}
 
[System.Serializable]
public class DialogueSentence
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string sentence;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueSentence> dialogueSentences = new List<DialogueSentence>();
}
 
public class DialogueTrigger : MonoBehaviour
{
    public bool thisTriggerHasPlayed = false;
    public Dialogue dialogue;
 
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
 
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            if(!thisTriggerHasPlayed)
            {
                TriggerDialogue();
                thisTriggerHasPlayed = true; //make it so same message won't play again if player walks past it

            }
        }
    }
}
