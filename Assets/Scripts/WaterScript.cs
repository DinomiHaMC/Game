using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaterScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private LightScript _light;

    private Rigidbody _playerRb;
    private Transform _playerTransform;
    private InventoryScript _playerInventory;

    [SerializeField] private Transform _spawnPos;

    [SerializeField] private Image _image;
    [SerializeField] private float _fadeTime;

    private void Start()
    {
        _playerRb = _player.GetComponent<Rigidbody>();
        _playerTransform = _player.transform;
        _playerInventory = _player.GetComponent<InventoryScript>();
    }

    public void Enter()
    {
        StartCoroutine(FadeSquence());
    }

    private IEnumerator FadeSquence()
    {
        _playerRb.linearDamping = 5;

        yield return StartCoroutine(Fade(0f, 1f));

        _playerTransform.position = _spawnPos.position;
        _light.DayTime = 0;
        _playerInventory.ClearInventory();

        yield return StartCoroutine(Fade(1f, 0f));

        _playerRb.linearDamping = 0;
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;

        Color color = _image.color;

        while (elapsed < _fadeTime)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / _fadeTime);
            _image.color = new Color(color.r, color.b, color.g, alpha);
            yield return null;
        }


    }

}
