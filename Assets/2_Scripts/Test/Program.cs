using UnityEngine;

public class Program : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello, World!");

        Publisher publisher = new Publisher();
        publisher.msg += ResultProcess;

        publisher.SendMessage("�ְ� �м� ��Ź �����!");

        Debug.Log("�۾� �Ϸ�!");
    }
    
    

    void ResultProcess(string msg)
    {
        Debug.Log("������ �޽���: " + msg);
    }
}

public class Publisher
{
    public delegate void OnMessage(string msg);
    public event OnMessage msg;

    public void SendMessage(string text)
    {
        Debug.Log($"ChatGPT API�� ����մϴ�.(1�� �ɸ�)... {text}");
        msg?.Invoke(text);
    }
}
