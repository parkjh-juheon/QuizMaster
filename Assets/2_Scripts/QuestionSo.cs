using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionSo : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]string questionText = "���⿡ ������ �����ּ���";
}
