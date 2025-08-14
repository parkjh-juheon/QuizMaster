using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionSo : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string questionText = "여기에 질문을 적어주세요";
}
