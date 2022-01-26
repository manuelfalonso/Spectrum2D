using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class GhostController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameEventSO _triggerHunt;
    [SerializeField] private float _rangeOfHunt = 1f;
    [SerializeField] private float _timeOfHunt = 5f;
    [SerializeField] private bool _isHunting = false;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    [SerializeField] private bool _isVisible = false;
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
    }

    void Update()
    {


        // false hunting.no visible
        if (!_isHunting)
        {
            IsVisible = false;
        }
        // true make Visible. if Player inside of range, target him. If touch kill him.
        else
        {
            IsVisible = true;
            Vector3 targetDistance = _target.transform.position - transform.position;
            if (targetDistance.magnitude <= _rangeOfHunt)
            {
                // Follow target;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _triggerHunt.Raise();
        }
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

    public void Test()
    {
        Debug.Log("Hello World");
    }
}
