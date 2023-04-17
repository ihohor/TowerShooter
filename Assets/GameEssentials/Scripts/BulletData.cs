using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet/Create new bullet", order = 51)]
public class BulletData : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _mass;
    [SerializeField] private Bullet _bulletPrefab;

    public Bullet BulletPrefab => _bulletPrefab;
    public float Mass => _mass;
    public float MoveSpeed => _moveSpeed;
    public float LifeTime => _lifeTime;
}
