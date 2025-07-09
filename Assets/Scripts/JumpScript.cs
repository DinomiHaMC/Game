using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private string _tag;
    private bool _canJump;

    public bool CanJump { get => _canJump; set => _canJump = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            _canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            _canJump = false;
        }
    }
}
