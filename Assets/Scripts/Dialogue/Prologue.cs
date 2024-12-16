using UnityEngine;

public class Prologue : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake()
{
    Invoke(nameof(StartDialogue), 4f); 
}

private void StartDialogue()
{
    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
}
}
