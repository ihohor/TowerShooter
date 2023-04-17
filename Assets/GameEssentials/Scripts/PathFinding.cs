using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private LayerMask _walkable;

    private float _maxDistance = 500;

    public Vector3 FindPath(Camera camera)
    {
        Ray myRay = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out var hitInfo, _maxDistance, _walkable))
            return hitInfo.point;

        return default;
    }
}
