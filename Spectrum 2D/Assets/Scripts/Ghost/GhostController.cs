using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class GhostController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEventSO _triggerStartHunt;
    [SerializeField] private GameEventSO _triggerFinishHunt;

    [Header("Ghost Hunt Parameters")]
    [SerializeField] private GameObject _target;

    [SerializeField] private float _rangeOfHunt = 1f;
    [SerializeField] private float _timeOfHunt = 5f;
    [Range(0f,1f)]
    [SerializeField] private float _chanceOfHunt = .3f;

    [Header("Current State")]
    [SerializeField] private bool _isHunting = false;
    [SerializeField] private bool _isVisible = false;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    private float _time = 0f;
    private float _timeToCheckHunt = 1f;

    public bool IsVisible { 
        get { return _isVisible; } 
        set 
        {
            if (value)
            {
                _spriteRenderer.enabled = value;
                _collider.enabled = value;
            }
            else
            {
                _spriteRenderer.enabled = value;
                _collider.enabled = value;
            }
            _isVisible = value;
        }
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        if (!_target)
        {
            _target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        CheckHunt();
        CheckState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If hunting and colliding with the player destroy it.
        if (_isHunting)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
                _target = null;
                _isHunting = false;
            }
        }
    }

    private void CheckHunt()
    {
        _time += Time.deltaTime;

        if (_time > _timeToCheckHunt)
        {
            if (_isHunting)
            {
                if (_time > _timeOfHunt)
                {
                    _isHunting = false;
                    _triggerFinishHunt.Raise();
                    _time = 0f;
                }
            }
            else
            {
                float randomChance = Random.Range(0f, 1f);

                if (randomChance < _chanceOfHunt)
                {
                    _isHunting = true;
                    _triggerStartHunt.Raise();
                }
                _time = 0f;
            }
        }
    }

    private void CheckState()
    {
        // false hunting.no visible
        if (!_isHunting)
        {
            IsVisible = false;
            GetComponent<AgentScript>().IsTargeting = false;
            GetComponent<Wander>().IsWandering = true;
        }
        // true make Visible. if Player inside of range, target him. If touch kill him.
        else
        {
            IsVisible = true;

            if (_target)
            {
                Vector3 targetDistance = _target.transform.position - transform.position;

                if (targetDistance.magnitude <= _rangeOfHunt)
                {
                    // Follow target;
                    GetComponent<AgentScript>().IsTargeting = true;
                    GetComponent<Wander>().IsWandering = false;
                }
                else
                {
                    // Wander
                    GetComponent<AgentScript>().IsTargeting = false;
                    GetComponent<Wander>().IsWandering = true;
                }
            }
        }
    }

    public void StartHunt()
    {
        Debug.Log("Start Hunt");
    }

    public void FinishHunt()
    {
        Debug.Log("Finish Hunt");
    }
}
