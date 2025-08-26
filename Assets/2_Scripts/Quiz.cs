using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo questions;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        GetNextQusetion();
    }

    private void GetNextQusetion()
    {
        SetButtonState(true);
        OnDisplayQuestion();
        SetDefaultButtonSprit();
    }

    private void SetDefaultButtonSprit()
    {
        foreach (GameObject obj in answerButtons)
        {
            obj.GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }


    private void OnDisplayQuestion()
    {
        questionText.text = questions.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions.GetAnswers(i);
        }
    }

    public void OnAnswerButtonClicked(int index)
    {
        if (index == questions.GetCorrectAnswerIndex())
        {
            questionText.text = "정답입니다.";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = "오답입니다. 아쉬워라" + questions.GetCorrectAnswerIndex();
        }
        SetButtonState(false);
    }

    private void SetButtonState(bool state)
    {
        foreach (GameObject obj in answerButtons)
        {
            obj.GetComponent<Button>().interactable = state;
        }
    }
}
