using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGPTClient : MonoBehaviour
{
    // �̺�Ʈ ��������Ʈ ����
    public delegate void QuestionsGeneratedHandler(List<QuestionSo> questions);
    public event QuestionsGeneratedHandler quizGenerateHandler;

    // ���� ���� ��û
    internal void GenerateQuestions(int questionCount, string topicToUse)
    {
        Debug.Log($"Generating {questionCount} questions on the topic: {topicToUse}");

        StartCoroutine(GenerateWithDelay());
    }

    // ���� �� ���� ����
    private IEnumerator GenerateWithDelay()
    {
        yield return new WaitForSeconds(3f);

        List<QuestionSo> questions = new List<QuestionSo>();

        QuestionSo q1 = CreateQuestion(
            "GPT ���� ���� 1",
            new string[] { "�亯1(����)", "�亯2", "�亯3", "�亯4" },
            0
        );
        questions.Add(q1);

        QuestionSo q2 = CreateQuestion(
            "GPT ���� ���� 2",
            new string[] { "�亯1", "�亯2(����)", "�亯3", "�亯4" },
            1
        );
        questions.Add(q2);

        QuestionSo q3 = CreateQuestion(
            "GPT ���� ���� 3",
            new string[] { "�亯1", "�亯2", "�亯3(����)", "�亯4" },
            2
        );
        questions.Add(q3);

        // �̺�Ʈ ȣ��
        quizGenerateHandler?.Invoke(questions);
        Debug.Log("Finished GenerateWithDelay...");
    }

    // ���� ScriptableObject ����
    QuestionSo CreateQuestion(string questionText, string[] answers, int correctAnswerIndex)
    {
        QuestionSo so = ScriptableObject.CreateInstance<QuestionSo>();
        so.SetData(questionText, answers, correctAnswerIndex);
        return so;
    }
}
