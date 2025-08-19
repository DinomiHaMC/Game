using UnityEngine;

public class Workbench : MonoBehaviour
{
    private UpgradeUIController _upgradeUI;
    private CameraComponent _camera;
    private UITag _ui;

    private void Start()
    {
        _upgradeUI = FindObjectOfType<UpgradeUIController>(true);
        _camera = FindAnyObjectByType<CameraComponent>();
        _ui = FindAnyObjectByType<UITag>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _upgradeUI.gameObject.SetActive(true);
            _camera.CameraLocker = true;
            _ui.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _upgradeUI.gameObject.SetActive(false);
            _camera.CameraLocker = false;
            _ui.gameObject.SetActive(true);
        }
    }
}
