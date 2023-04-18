using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private Transform _mouseTarget;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _targetPosition;

    public Vector3 GetMousePosition(Camera camera)
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
}
