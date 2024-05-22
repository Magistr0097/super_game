using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject gameInput;
    private string[] lines;
    public float speedText;
    public Text dialogueText;
    public GameObject continueText;
    public int index;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        this.lines = lines;
        gameObject.SetActive(true);
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void SkipText()
    {
        if (dialogueText.text == lines[index])
        {
            continueText.SetActive(false);
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            continueText.SetActive(true);
            dialogueText.text = lines[index];
        }
    }

    private void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameInput.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeLine()
    {
        foreach (var sym in lines[index])
        {
            dialogueText.text += sym;
            yield return new WaitForSeconds(speedText);
        }
        continueText.SetActive(true);
    }
}
