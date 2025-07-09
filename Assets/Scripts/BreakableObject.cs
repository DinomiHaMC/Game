using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private float _breakTime;
    //[SerializeField] private float _animTime;
    //[SerializeField] private string _animName;
    [SerializeField] private GameObject _woodItem;
    [SerializeField] private Transform _itemSpawnPos;

    private Animator _a;

    public float BreakTime { get => _breakTime; set => _breakTime = value; }

    private void Start()
    {
        _a = GetComponent<Animator>();
        _itemSpawnPos = transform;
    }

    public void OnBroken()
    {
        //_a.SetBool(_animName, true);
        Instantiate(_woodItem, _itemSpawnPos.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
