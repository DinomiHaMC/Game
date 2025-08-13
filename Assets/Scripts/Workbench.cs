using UnityEngine;

public class Workbench : MonoBehaviour
{
    private UpgradeUIController _upgradeUI;

    private void Start()
    {
        _upgradeUI = FindAnyObjectByType<UpgradeUIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _upgradeUI.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _upgradeUI.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
