using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    

    public void Retry()
    {
        Time.timeScale = 1f;
        GameObject.FindObjectOfType<SceneFader>().FadeTo(SceneManager.GetActiveScene().name);       
    }

    public void Menu()
    {
        Time.timeScale = 1f;      
        GameObject.FindObjectOfType<SceneFader>().FadeTo("_MainMenu_");
    }

}
