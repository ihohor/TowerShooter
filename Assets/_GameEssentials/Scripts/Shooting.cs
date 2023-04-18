using UnityEngine;

public class Shooting : BulletsPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawn;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }

    public void Shoot(Vector3 targetPosition)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aimDirection = (targetPosition - _bulletSpawn.position).normalized;

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
