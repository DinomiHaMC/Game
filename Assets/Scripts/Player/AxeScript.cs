using UnityEngine;
using UnityEngine.UI;

public class AxeScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _durability;

    [SerializeField] private float _gatherDistance;
    [SerializeField] private Transform _pointRayCast;

    [SerializeField] private ItemData _itemData;
    private ItemInstance _axeItem;

    private BreakableObject _currentTarget;
    private float _currentProgress;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _slider.gameObject.SetActive(false);
        _axeItem = new ItemInstance(_itemData);
    }

    private void Update()
    {
        var MouseLeft = Input.GetMouseButton(0);
        _animator.SetBool("AxeUse", MouseLeft);

        _durability.value = _axeItem.currentDurability / _axeItem.GetDurability();

        _slider.gameObject.SetActive(MouseLeft);
        if (MouseLeft)
        {
            var ray = new Ray(_pointRayCast.position, _pointRayCast.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, _gatherDistance))
            {
                var breakable = hit.collider.GetComponent<BreakableObject>();

                if (breakable != null)
                {
                    if (breakable != _currentTarget)
                    {
                        _currentTarget = breakable;
                        _currentProgress = 0;
                        _slider.value = 0;
                    }
                    if (!_axeItem.IsBroken)
                    {
                        _slider.gameObject.SetActive(true);
                        _currentProgress += Time.deltaTime * _axeItem.GetEffeciency();
                        _slider.value = _currentProgress / _currentTarget.BreakTime;
                    }

                    if(_currentProgress >= _currentTarget.BreakTime)
                    {
                        _currentTarget.OnBroken();
                        _axeItem.Use(0.1f);
                        ResetBreaking();

                        if (_axeItem.IsBroken)
                        {
                            print("Топор сломан!");
                        }
                    }
                }
                else
                {
                    ResetBreaking();
                }
            }
            else
            {
                ResetBreaking();
            }
        }
        else
        {
            ResetBreaking();
        }
    }

    private void ResetBreaking()
    {
        _currentTarget = null;
        _currentProgress = 0;
        _slider.value = 0;
        _slider.gameObject.SetActive(false);
    }

    public ItemInstance GetItem()
    {
        return _axeItem;
    }
}
