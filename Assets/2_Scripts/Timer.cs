using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float problemTime = 10f;
    [SerializeField] float solutionTime = 3f;

    [HideInInspector] public bool isProblemPhase = true;
    [SerializeField] float fillAmount= 10f;

    float time = 0;


    private void Start()
    {
        time = problemTime;
    }

    private void Update()
    {
        TimerCountDown();
        CalculateFillAmount();
    }

    private void CalculateFillAmount()
    {
        if (isProblemPhase)
        {
            fillAmount = time / problemTime;
        }
        else
        {
            fillAmount = 1 - (time / solutionTime);
        }
    }

    private void TimerCountDown()
    {
        Debug.Log("Time remaining: " + time);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (isProblemPhase)
            {
                isProblemPhase = false;
                time = solutionTime;
            }
            else
            {
                isProblemPhase = true;
                time = problemTime;
            }
            time = problemTime;
        }
    }
}
