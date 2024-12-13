using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        PT,
        ENG

    }

    public idiom language;

    [Header("Components")]

    public GameObject dialogueOBJ; // janela 
    public Image profileSprite;     // sprite perfil
    public Text speechText; // texto fala
    public Text actorNameText; // name NPC

    [Header("Settings")]

    public float typingSpeed; // velocidade da fala


    // variaveis de controle


    private bool isShowing; // está visivel?
    private int index; // leitor de quantidade 
    private string [] sentences;


    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

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
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // salto de frase // fala
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueOBJ.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    // inicia a fala do NPC
    public void Speech(string[] txt)
    {
        if(!isShowing)
        {
            dialogueOBJ.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
        
    }

}
