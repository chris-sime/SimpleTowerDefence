using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WavesSurvived : MonoBehaviour {

    public Text WavesText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }


    IEnumerator AnimateText()
    {
        int wave = 0;
        WavesText.text = "0";
        yield return new WaitForSeconds(.7f);

        while (wave < PlayerStats.WavesSurvived)
        {
            wave++;
            WavesText.text = wave.ToString();
            yield return new WaitForSeconds(.05f);
        }
                        
    }
}
