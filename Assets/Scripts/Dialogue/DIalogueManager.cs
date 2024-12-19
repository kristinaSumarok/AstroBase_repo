using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager: MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI displatNameText;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private static DialogueManager instance;
    private const string SPEAKER_TAG = "speaker";
    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one dialogue manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance(){
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
        currentStory.BindExternalFunction("loadScene", () => {
         SceneManager.LoadSceneAsync(2);
        });
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        panel.SetActive(false);
        text.text = "";
    }

    private void ContinueStory(){
        if (currentStory.canContinue){
            text.text = currentStory.Continue();
            HandleTags(currentStory.currentTags);
        }
        else{
            StartCoroutine(ExitDialogueMode());
        }
    }
    private void HandleTags(List<string> currentTags){
        foreach (string tag in currentTags){
            string[] splitTag = tag.Split(':');
            if (splitTag.Length !=2){
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            displatNameText.text = tagValue;

        }
    }

    
}
