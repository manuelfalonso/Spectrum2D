using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private bool _isHunting = false;

    private NavMeshAgent _agent;

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
        if (_isHunting)
        {
            _agent.SetDestination(_target.position);
        }
    }
}
