using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet/Create new bullet", order = 51)]
public class Bullet : ScriptableObject
{    
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _rigidBodyMass;
    [SerializeField] private Transform _bulletPrefab;

    public Transform BulletPrefab => _bulletPrefab;
    public float RigidBodyMass => _rigidBodyMass;
    public float BulletSpeed => _bulletSpeed;
    public float LifeTime => _lifeTime;  
}
