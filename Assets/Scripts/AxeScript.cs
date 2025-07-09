using UnityEngine;
using UnityEngine.UI;

public class AxeScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _gatherDistance;
    [SerializeField] private Transform _pointRayCast;

    private BreakableObject _currentTarget;
    private float _currentProgress;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _slider.gameObject.SetActive(false);
    }

    private void Update()
    {
        var MouseLeft = Input.GetMouseButton(0);
        _animator.SetBool("AxeUse", MouseLeft);

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

                    _slider.gameObject.SetActive(true);
                    _currentProgress += Time.deltaTime;
                    _slider.value = _currentProgress / _currentTarget.BreakTime;

                    if(_currentProgress >= _currentTarget.BreakTime)
                    {
                        _currentTarget.OnBroken();
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
}
