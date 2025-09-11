using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGPTClient : MonoBehaviour
{
    // 이벤트 델리게이트 정의
    public delegate void QuestionsGeneratedHandler(List<QuestionSo> questions);
    public event QuestionsGeneratedHandler quizGenerateHandler;

    // 질문 생성 요청
    internal void GenerateQuestions(int questionCount, string topicToUse)
    {
        Debug.Log($"Generating {questionCount} questions on the topic: {topicToUse}");

        StartCoroutine(GenerateWithDelay());
    }

    // 지연 후 질문 생성
    private IEnumerator GenerateWithDelay()
    {
        yield return new WaitForSeconds(3f);

        List<QuestionSo> questions = new List<QuestionSo>();

        QuestionSo q1 = CreateQuestion(
            "GPT 생성 질문 1",
            new string[] { "답변1(정답)", "답변2", "답변3", "답변4" },
            0
        );
        questions.Add(q1);

        QuestionSo q2 = CreateQuestion(
            "GPT 생성 질문 2",
            new string[] { "답변1", "답변2(정답)", "답변3", "답변4" },
            1
        );
        questions.Add(q2);

        QuestionSo q3 = CreateQuestion(
            "GPT 생성 질문 3",
            new string[] { "답변1", "답변2", "답변3(정답)", "답변4" },
            2
        );
        questions.Add(q3);

        // 이벤트 호출
        quizGenerateHandler?.Invoke(questions);
        Debug.Log("Finished GenerateWithDelay...");
    }

    // 질문 ScriptableObject 생성
    QuestionSo CreateQuestion(string questionText, string[] answers, int correctAnswerIndex)
    {
        QuestionSo so = ScriptableObject.CreateInstance<QuestionSo>();
        so.SetData(questionText, answers, correctAnswerIndex);
        return so;
    }
}
