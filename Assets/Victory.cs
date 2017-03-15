using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

    public string menuSceneName = "_MainMenu_";
    public string nextLevel = "_Level2_";

    public void Continue()
    {
        GameObject.FindObjectOfType<SceneFader>().FadeTo(nextLevel);
    }

    public void Menu()
    {
        GameObject.FindObjectOfType<SceneFader>().FadeTo(menuSceneName);
    }
	
}
