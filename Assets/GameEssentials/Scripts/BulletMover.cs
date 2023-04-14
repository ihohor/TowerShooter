using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private Bullet _bullets;

    private Rigidbody _bulletRigidBody;
    private float _bulletSpeed;
    private float _lifeTime;
    private float _timeAlive;

    private void Awake()
    {
        _bulletRigidBody = GetComponent<Rigidbody>();
        _lifeTime = _bullets.LifeTime;
        _bulletSpeed = _bullets.BulletSpeed;
    }

    private void Start()
    {
        _bulletRigidBody.velocity = transform.forward * _bulletSpeed;
        _bulletRigidBody.mass = _bullets.RigidBodyMass;
    }

    private void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive >= _lifeTime)
            Destroy(gameObject);
    }
}
