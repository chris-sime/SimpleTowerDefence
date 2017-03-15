using UnityEngine;


public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startingMoney = 400;
    
    public static int Lives;
    public int startingLives = 50;

    public static int WavesSurvived;
    
    void Start()
    {
        Money = startingMoney;      
        Lives = startingLives;
        WavesSurvived = 0;        
    }

    
}
