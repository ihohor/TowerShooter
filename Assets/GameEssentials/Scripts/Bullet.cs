using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;

    private Rigidbody _bulletRigidBody;

    private float _timeAlive;

    private void Awake()
    {
        _bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _bulletRigidBody.velocity = transform.forward * _bulletSpeed;
    }

    private void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive >= _lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
