using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string LoadToScene = "_TutorialLevel_";
    public SceneFader sceneFader; 

	public void Play()
    {
        sceneFader.FadeTo(LoadToScene);
    }
    public void SelectLevel()
    {
        sceneFader.FadeTo("_LevelSelect_");
    }
    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
