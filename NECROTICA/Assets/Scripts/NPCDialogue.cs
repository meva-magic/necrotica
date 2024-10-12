using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    private int index = 0;
    public float dialogueSpeed;

    public GameObject dialogue;

    //public Animator dialogueAnimator;
    private bool startDialogue = true;

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(startDialogue)
            {
                //dialogueAnimator.SetTrigger("Enter");
                dialogue.SetActive(true);
                startDialogue = false;
                PlayerMove.instance.isTalking = true;
            }

            else
            {
                NextLine();
            }
        }

    }

    private void NextLine()
    {
        if(index <= lines.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteLines());
        }

        else
        {
            dialogue.SetActive(false);

            //dialogueText.text = "";
            //dialogueAnimator.SetTrigger("Exit");
            index = 0;
            startDialogue = true;
            PlayerMove.instance.isTalking = false;
        }
    }

    IEnumerator WriteLines()
    {
        foreach(char Character in lines[index].ToCharArray())
        {
            dialogueText.text += Character;
            AudioManager.instance.Play("Voice");
            yield return new WaitForSeconds(dialogueSpeed);
        }

        index++;
    }
}