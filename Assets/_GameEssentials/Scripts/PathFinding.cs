using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private LayerMask _walkable;
    [SerializeField] private float _maxDistance;

    public Vector3 FindPath(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, _maxDistance, _walkable))
            return hit.point;

        return default;
    }
}
