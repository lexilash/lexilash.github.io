using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

 
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
 
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
 
    private Queue<DialogueSentence> sentences;
    
    public bool isDialogueActive = false;
 
    public float typeSpeed;
 
    public Animator dialogueAnim;
    [SerializeField] GameObject player;
    Movement movement;
    void Awake()
    {
        movement = player.GetComponent<Movement>();
    }
 
    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
 
        sentences = new Queue<DialogueSentence>();
    }
 
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        dialogueAnim.SetTrigger("Enter");
        
        movement.canMove = false;
        
         
 
        sentences.Clear();
 
        foreach (DialogueSentence dialogueSentence in dialogue.dialogueSentences)
        {
            sentences.Enqueue(dialogueSentence);
        }
 
        DisplayNextSentence();
        Update();

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }
 
    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
            StopDialogue();
            return;
        }
        
        DialogueSentence currentSentence = sentences.Dequeue();
 
        characterName.text = currentSentence.character.name;
 
        StopAllCoroutines();
 
        StartCoroutine(TypeSentence(currentSentence));
    }
 
    IEnumerator TypeSentence(DialogueSentence dialogueSentence)
    {
        dialogueArea.text = "";
        foreach (char letters in dialogueSentence.sentence.ToCharArray())
        {
            dialogueArea.text += letters;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
 
    void StopDialogue()
    {
        isDialogueActive = false;
        dialogueAnim.SetTrigger("Exit");
        movement.canMove = true;

    }
}
