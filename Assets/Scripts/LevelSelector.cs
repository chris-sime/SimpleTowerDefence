using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour {

    public SceneFader sceneFader;
    public Button[] levelButtons;
    
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = levelReached; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    } 

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }

    public void BackToMainMenu()
    {
        sceneFader.FadeTo("_MainMenu_");
    }
}
