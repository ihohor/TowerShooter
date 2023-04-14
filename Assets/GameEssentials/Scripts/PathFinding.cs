using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private LayerMask _whatCanBeClickedOn;

    private float _maxDistance = 500;

    public void FindPath(NavMeshAgent agent, bool onTop,Camera camera)
    {
        if (!onTop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(myRay, out hitInfo, _maxDistance, _whatCanBeClickedOn))
                    agent.SetDestination(hitInfo.point);               
            }
        }
    }
}
