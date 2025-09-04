using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("질문")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSo> questions = new List<QuestionSo>();
    QuestionSo currentQuestion;

    [Header("보기")]
    [SerializeField] GameObject[] answerButtons;

    [Header("버튼 색깔")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("타이머")]
    [SerializeField] Image timerImge;
    [SerializeField] Sprite problemTimerSprite;
    [SerializeField] Sprite solutionTimerSprite;
    Timer timer;
    bool chooseAnswer = false;

    [Header("점수")]
    [SerializeField] TextMeshProUGUI scoerText;
    ScoerKeeper ScoerKeeper;

    [Header("바")]
    [SerializeField] Slider progressber;
    //public bool isComplete = false;

    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        ScoerKeeper = FindFirstObjectByType<ScoerKeeper>(); // 먼저 초기화
        progressber.value = 0;
        progressber.maxValue = questions.Count;

        GetNextQuestion();
    }

    private void Update()
    {
        // Timer 이미지 업데이트
        timerImge.fillAmount = timer.fillAmount;

        if (timer.isProblemTime)
        {
            timerImge.sprite = problemTimerSprite;
        }
        else
        {
            timerImge.sprite = solutionTimerSprite;
        }

        // 다음 문제 불러오기
        if (timer.loadNextQuestion)
        {
            if (questions.Count <= 0)
            {
                // 모든 문제를 다 풀면 End 화면 출력
                GameManager.Instance.ShowEndScreen();
            }
            else
            {
                // 문제 아직 남아 있으면 다음 문제 불러오기
                timer.loadNextQuestion = false;
                GetNextQuestion();
            }
        }

        // SolutionTime이고 답을 선택하지 않았을 때
        if (timer.isProblemTime == false && chooseAnswer == false)
        {
            DisplaySolution(-1);
        }
    }


    private void GetNextQuestion()
    {
        if (questions.Count <= 0)
        {
            Debug.Log("더이상 질문이 없습니다.");
            return;
        }

        chooseAnswer = false;
        SetButtonState(true);
        SetDefaultButtonSprites();  // 버튼 초기화 먼저
        GetRandomQuestion();        // 그 다음 랜덤 질문 뽑기
        OnDisplayQuestion();        // 마지막으로 UI 표시
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
            questionText.text = "정답입니다.";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
            ScoerKeeper.IncrementCurrectAnswer();
        }
        else
        {
            questionText.text = "오답입니다. 아쉬워라 정답은 " + currentQuestion.GetCorrectAnswer();
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