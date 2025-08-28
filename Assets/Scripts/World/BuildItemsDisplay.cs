using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildItemsDisplay : MonoBehaviour
{
    [SerializeField] private BuildScript _buildScript;
    [SerializeField] private InventoryScript _inv;

    [SerializeField] private Image _thread;
    [SerializeField] private Image _wood;
    [SerializeField] private TextMeshProUGUI _woodText;
    [SerializeField] private TextMeshProUGUI _threadText;

    private void Update()
    {
        if (_buildScript.BuildMode)
        {
            if (_buildScript.BuildObject != 3)
            {
                _thread.gameObject.SetActive(false);
                _wood.gameObject.SetActive(true);
                _woodText.text = "Wood x1";
                if(_inv.WoodCount > 0)
                {
                    _woodText.color = Color.white;
                }
                else
                {
                    _woodText.color = Color.red;
                }
            }
            else if (_buildScript.BuildObject == 3)
            {
                _thread.gameObject.SetActive(true);
                _wood.gameObject.SetActive(true);
                _threadText.text = "Thread x2";
                _woodText.text = "Wood x2";
                if (_inv.WoodCount >= 2)
                {
                    _woodText.color = Color.white;
                }
                else
                {
                    _woodText.color = Color.red;
                }

                if (_inv.ThreadCount >= 2)
                {
                    _threadText.color = Color.white;
                }
                else
                {
                    _threadText.color = Color.red;
                }
            }
        }
        else
        {
            _thread.gameObject.SetActive(false);
            _wood.gameObject.SetActive(false);
            _threadText.text = "";
            _woodText.text = "";
        }

    }
}
