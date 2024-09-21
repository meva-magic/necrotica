using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    private int index = 0;
    public float dialogueSpeed;

    public Animator dialogueAnimator;
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
                startDialogue = false;
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
            dialogueText.text = "";
            dialogueAnimator.SetTrigger("Exit");
            index = 0;
            startDialogue = true;
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