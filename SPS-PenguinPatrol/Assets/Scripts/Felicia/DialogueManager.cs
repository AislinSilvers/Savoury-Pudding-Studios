using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public CanvasGroup canvasGroup;
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    public Button[] continueButton;
    public Button[] choiceButtons;

    public bool isDialogueActive;
    //public bool dialogueActivated;

    private DialogueSO currentDialogue;
    private int dialogueIndex;

    private float lastDialogueEndTime;
    private float dialogueCooldown = 1;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false; 

        foreach (var button in choiceButtons)
            button.gameObject.SetActive(false);
    }

    /*
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogueActivated = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        dialogueActivated = false;
    }
    */

    public void StartDialogue(DialogueSO dialogueSO)
    {
        if (Time.unscaledTime - lastDialogueEndTime < dialogueCooldown)
            return;

        currentDialogue = dialogueSO;
        dialogueIndex = 0;
        isDialogueActive = true;
        ShowDialogue();
    }

    public void AdvanceDialogue()
    {
        if (dialogueIndex < currentDialogue.lines.Length)
            ShowDialogue();
        else
            ShowChoices();
        //else
            //EndDialogue();
    }


    private void ShowDialogue()
    {
        DialogueLine line = currentDialogue.lines[dialogueIndex];

        portrait.sprite = line.speaker.portrait;
        actorName.text = line.speaker.actorName;

        dialogueText.text = line.text;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        dialogueIndex++;
    }

    private void ShowChoices()
    {
        if(currentDialogue.options.Length > 0)
        {
            for (int i = 0; i < currentDialogue.options.Length; i++)
            {
                var option = currentDialogue.options[i];

                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = option.optionText;
                choiceButtons[i].gameObject.SetActive(true);
            }
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueIndex = 0;
        isDialogueActive = false;

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        lastDialogueEndTime = Time.unscaledTime;
    }
}
