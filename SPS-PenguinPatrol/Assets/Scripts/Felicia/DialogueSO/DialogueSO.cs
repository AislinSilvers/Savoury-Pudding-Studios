using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject
{
    public DialogueLine[] lines;
    public DialogueOption[] options;
}

[System.Serializable]
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(1,20)] public string text;
}

[System.Serializable]
public class DialogueOption
{
    public string optionText;
    public DialogueSO nextDialogue;
}
