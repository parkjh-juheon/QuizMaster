using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionSo : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string questionText = "여기에 질문을 적어주세요";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex = 0;


    public string GetQuestion()
    {
        return questionText;
    }
    
    public string GetCorrectAnswer()
    {
        return answers[correctAnswerIndex];
    }

    public string GetAnswers(int index)
    {
        return answers[index];
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
