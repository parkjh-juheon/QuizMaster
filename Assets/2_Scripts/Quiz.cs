using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("����")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSo> questions = new List<QuestionSo>();
    QuestionSo currentQuestion;

    [Header("����")]
    [SerializeField] GameObject[] answerButtons;

    [Header("��ư ����")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Ÿ�̸�")]
    [SerializeField] Image timerImge;
    [SerializeField] Sprite problemTimerSprite;
    [SerializeField] Sprite solutionTimerSprite;
    Timer timer;
    bool chooseAnswer = false;

    [Header("����")]
    [SerializeField] TextMeshProUGUI scoerText;
    ScoerKeeper ScoerKeeper;

    [Header("��")]
    [SerializeField] Slider progressber;
    //public bool isComplete = false;

    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        ScoerKeeper = FindFirstObjectByType<ScoerKeeper>(); // ���� �ʱ�ȭ
        progressber.maxValue = questions.Count;
        progressber.value = 0;

        GetNextQuestion();
    }

    private void Update()
    {
        timerImge.fillAmount = timer.fillAmount;
        if (timer.isProblemTime)
        {
            timerImge.sprite = problemTimerSprite;
        }
        else
        {
            timerImge.sprite = solutionTimerSprite;
        }

        if (timer.loadNextQuestion)
        {
            timer.loadNextQuestion = false;
            GetNextQuestion();
        }

        if (timer.isProblemTime == false && chooseAnswer == false)
        {
            DisplaySolution(-1);
        }
    }

    private void GetNextQuestion()
    {
        if (questions.Count <= 0)
        {
            Debug.Log("���̻� ������ �����ϴ�.");
            return;
        }

        chooseAnswer = false;
        SetButtonState(true);
        SetDefaultButtonSprites();  // ��ư �ʱ�ȭ ����
        GetRandomQuestion();        // �� ���� ���� ���� �̱�
        OnDisplayQuestion();        // ���������� UI ǥ��
        ScoerKeeper.IncrementquestionSeen();
        progressber.value++;
    }

    private void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomIndex];
        questions.RemoveAt(randomIndex);
    }

    private void SetDefaultButtonSprites()
    {
        foreach (GameObject obj in answerButtons)
        {
            obj.GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    private void OnDisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.GetAnswers(i);
        }
    }

    public void OnAnswerButtonClicked(int index)
    {
        chooseAnswer = true;
        DisplaySolution(index);

        timer.CancelTimer();
        scoerText.text = $"Scoer:   {ScoerKeeper.CalculateScore()} %";

        /* if (progressber.value == progressber.maxValue)
         {
             isComplete = true;
         }*/
    }

    private void DisplaySolution(int index)
    {
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "�����Դϴ�.";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
            ScoerKeeper.IncrementCurrectAnswer();
        }
        else
        {
            questionText.text = "�����Դϴ�. �ƽ����� ������ " + currentQuestion.GetCorrectAnswer();
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