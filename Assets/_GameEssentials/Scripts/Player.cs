using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Aiming))]
[RequireComponent(typeof(Shooting))]
[RequireComponent(typeof(PathFinding))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private PlayerAnimator _playerAnimator;
    private NavMeshAgent _myAgent;
    private PathFinding _pathFinding;
    private Shooting _shooting;
    private Aiming _aiming;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _pathFinding = GetComponent<PathFinding>();
        _shooting = GetComponent<Shooting>();
        _aiming = GetComponent<Aiming>();
    }

    private void Update()
    {
        _targetPosition = _aiming.GetMousePosition(_camera);

        if (Input.GetMouseButtonDown(1))
        {           
            var newDestination = _pathFinding.FindPath(_camera);

            if (newDestination != default)
            {
                _myAgent.SetDestination(newDestination);
            }

        }

        if (_myAgent.hasPath)
        {
            _playerAnimator.StartRunning();
            _playerAnimator.ChangeMoveSpeed(_myAgent.velocity.magnitude);
        }
        else
        {
            _playerAnimator.StartAiming();
            _aiming.TurnToMouse();
            _shooting.Shoot(_targetPosition);
        }
    }
}
