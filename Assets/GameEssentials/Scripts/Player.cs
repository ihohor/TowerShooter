using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private PlayerAnimator _playerAnimator;
    private NavMeshAgent _myAgent;
    private PathFinding _pathFinding;
    private Shooting _shooting;

    private void Awake()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _pathFinding = GetComponent<PathFinding>();
        _shooting = GetComponent<Shooting>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var newDestination = _pathFinding.FindPath(_camera);

            if (newDestination != default)
                _myAgent.SetDestination(newDestination);
        }

        if (_myAgent.hasPath)
        {
            _playerAnimator.StartRunning();
            _playerAnimator.ChangeMoveSpeed(_myAgent.velocity.magnitude);
            _shooting.AimToMouse(_camera);
        }
        else
        {
            _shooting.AimToMouse(_camera);
            _shooting.TurnToMouse();
            _shooting.Shoot();
            _playerAnimator.StartAiming();
        }
    }
}
