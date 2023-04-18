using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _mass;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = _mass;
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

    private void Deacivate()
    {
        gameObject.SetActive(false);
    }
}
