using UnityEngine;

public class Shooting : BulletsPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private Transform _mouseTarget;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _targetPosition;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }

    public Vector3 AimToMouse(Camera camera)
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            _mouseTarget.position = hit.point;
            _targetPosition = hit.point;
            return _targetPosition;
        }
        return default;         
    }

    public void TurnToMouse()
    {
        Vector3 aimTarget = _targetPosition;
        aimTarget.y = transform.position.y;
        Vector3 aimDirection = (aimTarget - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, aimDirection, _rotationSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aimDirection = (_targetPosition - _bulletSpawn.position).normalized;

            if (TryGetObject(out var bullet))
            {
                SetBullet(bullet, _bulletSpawn.position, aimDirection);
            }
        }
    }

    private void SetBullet(GameObject bullet, Vector3 spawnPoint, Vector3 aimDirection)
    {
        bullet.transform.position = spawnPoint;
        bullet.transform.rotation = Quaternion.LookRotation(aimDirection, Vector3.up);
        bullet.SetActive(true);
    }
}
