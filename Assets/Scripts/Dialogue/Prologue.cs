using UnityEngine;

public class Prologue : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake(){
        Debug.Log(inkJSON.text);
    }
}
