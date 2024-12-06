using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public bool playerHit;
    public DialogueSettings dialogue;
    private List <string> sentences = new List<string>();
   
    void Start()
    {
        GetNPCInfo();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }


    void FixedUpdate()
    {
        ShowDialogue();
    }


    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueControl.instance.dialogueOBJ.SetActive(false);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
