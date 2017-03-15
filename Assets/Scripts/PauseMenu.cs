using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject Ui;
	
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        Ui.SetActive(!Ui.activeSelf);

        if (Ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }
	
	
}
