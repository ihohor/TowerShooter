using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private BulletManager _bulletManager;
    [SerializeField] public Transform _bulletSpawn;
    [SerializeField] public Transform _mouseTarget;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _targetPosition;

    public void AimToMouse(Camera camera)
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
            _mouseTarget.position = hit.point;
            _targetPosition = hit.point;

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
            Instantiate(_bulletManager.GetActiveBullet(), _bulletSpawn.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            //CHANGE TO POOL PATERN
        }
    }
}
