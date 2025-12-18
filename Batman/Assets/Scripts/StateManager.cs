using UnityEngine;

public enum GameState
{
    Normal,
    Stealth,
    Alert
}

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    public GameState currentState = GameState.Normal;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        //با توجه به ورودی استیت مشخص میشود
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetState(GameState.Normal);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SetState(GameState.Stealth);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(GameState.Alert);
        }
    }

    //تغییر استیت به استیت جدید
    public void SetState(GameState newState)
    {
        currentState = newState;
    }
}