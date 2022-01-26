using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minDistanceFromPlayer = 0.5f;
    [SerializeField] private bool _isHunting = false;

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
        _distanceToPlayer = _target.position - transform.position;
        if (_isHunting && _distanceToPlayer.magnitude < _minDistanceFromPlayer)
        {
            _agent.SetDestination(_target.position);
        }
    }

    public void TriggerHunt(GameObject target)
    {
        _isHunting = !_isHunting;
        _target = target.transform;
    }
}
