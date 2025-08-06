using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Events;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private string[] _tag;
    [SerializeField] private UnityEvent _event;
    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in _tag)
        {
            if (other.gameObject.CompareTag(tag))
            {
                _event?.Invoke();
                break;
            }
        }
    }
}
