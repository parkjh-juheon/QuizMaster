using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static GameManager Instance { get; private set; }

    // Awake���� �̱��� �ν��Ͻ� �Ҵ� �� �ߺ� ����
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // ���� ����Ǿ �ı����� �ʰ� ���� (�ʿ��)
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start�� ù Update ���� �� �� ȣ���
    void Start()
    {
        
    }

    // Update�� �� �����Ӹ��� ȣ���
    void Update()
    {
        
    }
}
