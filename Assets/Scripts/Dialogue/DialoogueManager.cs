using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialoogueManager: MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI text;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private static DialoogueManager instance;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one dialogue manager in the scene");
        }
        instance = this;
    }

    public static DialoogueManager GetInstance(){
        return instance;
    }

    private void Start(){
        dialogueIsPlaying = false;
        panel.SetActive(false);
    }

    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }

        if(InputManager.GetInstance().GetSubmitPressed()){
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        panel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode(){
        dialogueIsPlaying = false;
        panel.SetActive(false);
        text.text = "";
    }

    private void ContinueStory(){
        if (currentStory.canContinue){
            text.text = currentStory.Continue();
        }
        else{
            ExitDialogueMode();
        }
    }

    
}
