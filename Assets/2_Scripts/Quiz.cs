using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("질문")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo questions;

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

    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
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
        chooseAnswer = false;
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
        Debug.Log("DisplayQuestion" + questions.GetQuestion());
        questionText.text = questions.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions.GetAnswers(i);
        }
    }

    public void OnAnswerButtonClicked(int index)
    {
        chooseAnswer = true;
        DisplaySolution(index);
        timer.CancelTimer();
    }

    private void DisplaySolution(int index)
    {
        if (index == questions.GetCorrectAnswerIndex())
        {
            questionText.text = "정답입니다.";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = "오답입니다. 아쉬워라 정답은" + questions.GetCorrectAnswerIndex();
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
