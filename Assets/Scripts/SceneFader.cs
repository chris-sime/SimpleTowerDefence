using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());

    }

    public void FadeTo(string LevelName)
    {
        StartCoroutine(FadeOut(LevelName));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string level)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
        SceneManager.LoadScene(level);
    }
	
}
