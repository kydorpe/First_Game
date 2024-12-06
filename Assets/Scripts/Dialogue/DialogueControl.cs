using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]

    public GameObject dialogueOBJ; // janela 
    public Image profileSprite;     // sprite perfil
    public Text speechText; // texto fala
    public Text actorNameText; // name NPC

    [Header("Settings")]

    public float typingSpeed; // velocidade da fala


    // variaveis de controle


    private bool isShowing; // est� visivel?
    private int index; // leitor de quantidade 
    private string [] sentences;


    public static DialogueControl instance;


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