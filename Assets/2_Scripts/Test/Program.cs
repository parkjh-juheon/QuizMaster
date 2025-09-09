using UnityEngine;

public class Program : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello, World!");

        Publisher publisher = new Publisher();
        publisher.msg += ResultProcess;

        publisher.SendMessage("주가 분석 부탁 드려요!");

        Debug.Log("작업 완료!");
    }
    
    

    void ResultProcess(string msg)
    {
        Debug.Log("수신한 메시지: " + msg);
    }
}

public class Publisher
{
    public delegate void OnMessage(string msg);
    public event OnMessage msg;

    public void SendMessage(string text)
    {
        Debug.Log($"ChatGPT API와 통신합니다.(1분 걸림)... {text}");
        msg?.Invoke(text);
    }
}
