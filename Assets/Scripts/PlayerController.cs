using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private Slider _healthSlider;

    [SerializeField][Range(0, 100)] private int _health = 100;

    private Rigidbody _rb;
    private bool _isGrounded;

    [SerializeField] private float _horizontal;
    [SerializeField] private float _vertical;
    [SerializeField] private Vector3 _localInput;
    [SerializeField] private JumpScript _jumpScript;

    public int Health { get => _health; set => _health = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _healthSlider.value = (float)_health / 100f;

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            Vector3 localInput = new Vector3(_horizontal, 0, _vertical);
            Vector3 worldDir = transform.TransformDirection(localInput) * _speed;

            _rb.linearVelocity = new Vector3(worldDir.x, _rb.linearVelocity.y, worldDir.z);
        }
    }

    private void Jump()
    {
        if (_jumpScript.CanJump)
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
    }
}

