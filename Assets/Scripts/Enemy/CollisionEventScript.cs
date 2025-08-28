using UnityEngine;
using UnityEngine.Events;

public class ColisionEventScript : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent _event;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            _event?.Invoke();
        }
    }
}
