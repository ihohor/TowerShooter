using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _mouseTarget;
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] public Transform _bulletSpawn;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _targetPosition;

    public void AimToMouse(Camera camera,bool onTop)
    {
        if (onTop)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast( ray, out RaycastHit hit))
            {
                _mouseTarget.position = hit.point;
                _targetPosition = hit.point;
            }

            Vector3 aimTarget = _targetPosition;
            aimTarget.y = transform.position.y;
            Vector3 aimDirection = (aimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, _rotationSpeed * Time.deltaTime);
        }
    }
    public void Shoot(bool onTop)
    {
        if (onTop)
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 aimDirection = (_targetPosition - _bulletSpawn.position).normalized;
                Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.LookRotation(aimDirection, Vector3.up));           
            } 
    }
}
