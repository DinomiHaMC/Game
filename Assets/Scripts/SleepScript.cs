using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SleepScript : MonoBehaviour
{
    [SerializeField] private TreeSpawner _treeSpawner;
    [SerializeField] private LightScript _lightScript;

    [SerializeField] private float _fadeTime;
    [SerializeField] private Image _image;

    public void Sleep()
    {
        if(_lightScript.DayTime > 0.5)
        {
            StartCoroutine(FadeSquence());
        }

    }


    private IEnumerator FadeSquence()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        _treeSpawner.SpawnTrees();
        _lightScript.DayTime = 0;

        yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;

        Color color = _image.color;

        while(elapsed < _fadeTime)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / _fadeTime);
            _image.color = new Color(color.r, color.b, color.g, alpha);
            yield return null;
        }

        _image.color = new Color(color.r, color.b, color.g, endAlpha);
    }
}
