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
        if (Input.GetKeyDown(KeyCode.N))
            SetState(GameState.Normal);

        else if (Input.GetKeyDown(KeyCode.C))
            SetState(GameState.Stealth);

        else if (Input.GetKeyDown(KeyCode.Space))
            SetState(GameState.Alert);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
    }
}