using System.Collections;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light _sun;
    private bool _fogBoolean = false;

    [SerializeField] private float _dayDuration;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private float _time;

    public float DayTime { get => _time; set => _time = value; }

    private void Start()
    {
        _sun = GetComponent<Light>();
    }

    private void Update()
    {
        _time += Time.deltaTime / _dayDuration;
        if (_time > 1) _time = 0;

        var sunAngle = _time * 360f;
        transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);

        _sun.color = _gradient.Evaluate(_time);
        _sun.intensity = _curve.Evaluate(_time);

        if(_time > 0.6 && _fogBoolean == false)
        {
            StartCoroutine(Fog(0.015f, 0.1f, 1f));
            _fogBoolean = true;
        }
        else if(_time < 0.1 && _fogBoolean == true)
        {
            StartCoroutine(Fog(0.1f, 0.015f, 1f));
            _fogBoolean = false;
        }
    }

    private IEnumerator Fog(float startDensity, float endDensity, float fogTime)
    {
        float elapsed = 0f;

        while (elapsed < fogTime)
        {
            elapsed += Time.deltaTime;
            float fogDensity = Mathf.Lerp(startDensity, endDensity, elapsed / fogTime);
            RenderSettings.fogDensity = fogDensity;
            yield return null;
        }

        RenderSettings.fogDensity = endDensity;
    }
}
