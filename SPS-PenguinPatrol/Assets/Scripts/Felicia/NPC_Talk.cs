using UnityEngine;

public class NPC_Talk : MonoBehaviour
{
    private BoxCollider boxCollider;
    public DialogueSO dialogueSO;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if (DialogueManager.Instance.isDialogueActive)
                        DialogueManager.Instance.AdvanceDialogue();
            else
                        DialogueManager.Instance.StartDialogue(dialogueSO);
        }
    }






}
