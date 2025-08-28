using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private PlayerController _player;
    private Rigidbody _rbPlayer;
    private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    [SerializeField] private float _forceStrange;
    [SerializeField] private int _damage;
    [SerializeField] private float _dirY;


    private void Start()
    {

        _agent = GetComponent<NavMeshAgent>();

        _player = FindAnyObjectByType<PlayerController>();

        _target = _player.transform;

        _rbPlayer = _target.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_target != null)
        {
            _agent.SetDestination(_target.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.CanMove = false;

            var rb = collision.gameObject.GetComponent<Rigidbody>();

            var direction = (collision.gameObject.transform.position - transform.position).normalized;

            //direction.y = _dirY;

            //direction = direction.normalized;

            print(direction);

            _player.Health -= _damage;


            //Debug.DrawRay(collision.transform.position, direction * _forceStrange, Color.red, 1f);

            rb.AddForce(direction * _forceStrange, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.CanMove = true;
        }
    }

    public void Touch()
    {
        _player.CanMove = false;

        var direction = (_target.position - transform.position).normalized;

        direction.y = _dirY;

        direction = direction.normalized;

        print(direction);

        _player.Health -= _damage;


        Debug.DrawRay(_target.position, direction * _forceStrange, Color.red, 1f);

        _rbPlayer.AddForce(direction * _forceStrange, ForceMode.Impulse);

        _player.CanMove = true;
    }
}
