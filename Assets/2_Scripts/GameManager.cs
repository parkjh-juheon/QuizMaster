using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    // Awake에서 싱글톤 인스턴스 할당 및 중복 방지
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // 씬이 변경되어도 파괴되지 않게 설정 (필요시)
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start는 첫 Update 전에 한 번 호출됨
    void Start()
    {
        
    }

    // Update는 매 프레임마다 호출됨
    void Update()
    {
        
    }
}
