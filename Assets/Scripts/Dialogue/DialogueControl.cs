using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng
    }
    public idiom language;
    
    
    [Header("Components")]   

    public GameObject dialogueOBJ; // janela 
    public Image profileSprite;     // sprite perfil
    private Text speechText; // texto fala
    public Text actorNameText; // name NPC

    [Header("Settings")]

    public float typingSpeed; // velocidade da fala


    // variaveis de controle

   
    private bool isShowing; // está visivel?
    private int index; // leitor de quantidade 
    private string [] sentences;


    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }
    public string[] Sentences { get => sentences; set => sentences = value; }
    public Text SpeechText { get => speechText; set => speechText = value; }

    public void Awake ()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    IEnumerator TypeSentence ()
    {
        foreach (char letter in Sentences[index].ToCharArray())
        {
            SpeechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // salto de frase // fala
    public void NextSentence()
    {
        if (SpeechText.text == Sentences[index])
        {
            if (index < Sentences.Length - 1)
            {
                index++;
                SpeechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                SpeechText.text = "";
                index = 0;
                dialogueOBJ.SetActive(false);
                Sentences = null;
                IsShowing = false;
            }
        }
    }

    // inicia a fala do NPC
    public void Speech(string[] txt)
    {
        if(!IsShowing)
        {
            dialogueOBJ.SetActive(true);
            Sentences = txt;
            StartCoroutine(TypeSentence());
            IsShowing = true;
        }
        
    }

}
