using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo questions;
    //[SerializeField] TextMeshProUGUI[] answerText;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    void Start()
    {
        questionText.text = questions.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            //answerText[i].text = questions.GetAnswers(i);
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

    }
}
