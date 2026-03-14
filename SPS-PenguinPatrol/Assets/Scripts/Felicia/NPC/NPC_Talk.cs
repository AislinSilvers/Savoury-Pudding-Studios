using UnityEngine;

public class NPC_Talk : MonoBehaviour
{
    private BoxCollider boxCollider;
    public Animator interactAnimator;
    public DialogueSO dialogueSO;
    public bool dialogueActivated;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        interactAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact") && dialogueActivated == true)
        {
            if (DialogueManager.Instance.isDialogueActive)
                        DialogueManager.Instance.AdvanceDialogue();
            else
                        DialogueManager.Instance.StartDialogue(dialogueSO);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueActivated = true;
            interactAnimator.Play("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueActivated = false;
        interactAnimator.Play("Close");
    }



}
