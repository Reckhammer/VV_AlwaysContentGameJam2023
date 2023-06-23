using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    public EndScreenUI endScreen;
    public UnityEvent onFinished;
    public Health Player;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Player.onDeath.AddListener(ShowLoseScreen);
        onFinished.AddListener(ShowWinScreen);
    }

    public void ShowWinScreen()
    {
        Debug.Log("Player has reached Destination. Show the Win Screen");
        endScreen.SetWinScreen();
        endScreen.gameObject.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        Debug.Log("Player has died. Show the Lose Screen");
        endScreen.SetLoseScreen();
        endScreen.gameObject.SetActive(true);
    }
}
