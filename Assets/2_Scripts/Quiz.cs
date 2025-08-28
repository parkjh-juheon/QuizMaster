using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("����")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo questions;

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

    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        GetNextQusetion();
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
            GetNextQusetion();
        }

        if (timer.isProblemTime == false && chooseAnswer == false)
        {
            DisPlaySolution(-1);
        }
    }

    private void GetNextQusetion()
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
        DisPlaySolution(index);
        timer.CancelTimer();
    }

    private void DisPlaySolution(int index)
    {
        if (index == questions.GetCorrectAnswerIndex())
        {
            questionText.text = "�����Դϴ�.";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = "�����Դϴ�. �ƽ����� ������" + questions.GetCorrectAnswerIndex();
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
