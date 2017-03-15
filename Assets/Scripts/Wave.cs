using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {
    [HideInInspector]
    public string name = "EnemyType";

    public GameObject[] Enemy;
    public int[] count;
    public float rate;

}
