using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _mass;

    private Rigidbody _rigidbody;

    private float _currentLifeTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke("Deacivate", _maxLifeTime);
        _rigidbody.velocity = transform.forward * _moveSpeed;
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Start()
    {
        _rigidbody.mass = _mass;
    }

    public void SetDirection()
    {
    }

    private void Deacivate()
    {
        gameObject.SetActive(false);
    }


}
