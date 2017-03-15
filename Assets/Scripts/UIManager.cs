using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text MoneyUi;
    public Text LivesUi;
    public Text CountdownUi;
    public GameObject GameOverUi;
    public Text CurrentWaveUi;
    

    public static UIManager instance;
    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        MoneyUi.text = PlayerStats.Money.ToString();
        LivesUi.text = PlayerStats.Lives.ToString();
        
    }

	// Update is called once per frame
	void Update () {
        if (PlayerStats.Money >= 1000 && PlayerStats.Money < 10000)
        {
            MoneyUi.fontSize = 45;
        }
        else if (PlayerStats.Money >= 10000)
        {
            MoneyUi.fontSize = 35;
        }
        else
        {
            MoneyUi.fontSize = 55;
        }
    }
}
