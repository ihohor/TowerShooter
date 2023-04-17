using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData _data;

    private Rigidbody _rigidbody;

    private float _moveSpeed;
    private float _maxLifeTime;
    private float _currentLifeTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _maxLifeTime = _data.LifeTime;
        _moveSpeed = _data.MoveSpeed;
    }

    private void Start()
    {
        _rigidbody.velocity = transform.forward * _moveSpeed;
        _rigidbody.mass = _data.Mass;
    }

    private void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= _maxLifeTime)
            Destroy(gameObject);
        //CHANGE TO POOL PATERN
    }
}
