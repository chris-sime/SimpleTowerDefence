using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;
    UIManager UiManager;
    public GameObject victoryScreen;

    public int levelToUnlock = 3;

    void Start()
    {
        GameIsOver = false;
        UiManager = UIManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameIsOver) return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }	
	}

    void EndGame()
    {
        GameIsOver = true;
        UiManager.GameOverUi.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Level WON");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        victoryScreen.SetActive(true);
    }
}
