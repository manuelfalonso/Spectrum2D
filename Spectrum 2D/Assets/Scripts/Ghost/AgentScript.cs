using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public bool IsTargeting = false;

    [SerializeField] private Transform _target;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minDistanceFromPlayer = 0.5f;

    private NavMeshAgent _agent;
    private Vector3 _distanceToPlayer;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _maxSpeed;

        if (!_target)
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (IsTargeting)
        {
            if (_target)
            {
                _distanceToPlayer = _target.position - transform.position;

                if (_distanceToPlayer.magnitude > _minDistanceFromPlayer)
                {
                    _agent.SetDestination(_target.position);
                }
            }
        }
        else
        {
            _agent.ResetPath();
        }
    }
}
