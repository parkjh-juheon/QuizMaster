using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo questions;
    [SerializeField] TextMeshProUGUI[] answerText;
    void Start()
    {
        questionText.text = questions.GetQuestion();

        //answerText[0].text = questions.GetAnswers(0);
        //answerText[1].text = questions.GetAnswers(1);
        //answerText[2].text = questions.GetAnswers(2);
        //answerText[3].text = questions.GetAnswers(3);

        for (int i = 0; i < answerText.Length; i++)
        {
            answerText[i].text = questions.GetAnswers(i);
        }
    }

    void Update()
    {

    }
}
