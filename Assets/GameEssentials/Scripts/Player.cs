using GameEssentials.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class Player : MonoBehaviour, IShootingman
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Rig _rig;

    private PlayerAnimator _playerAnimator;
    private NavMeshAgent _myAgent;
    private PathFinding _pathFinding;
    private Shooting _shooting;

    private bool _isShootMode;

    private const float MaxRigWeight = 1f;

    private void Awake()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _pathFinding = GetComponent<PathFinding>();
        _shooting = GetComponent<Shooting>();
    }

    private void Update()
    {
        if (_isShootMode)
        {
            _shooting.AimToMouse(_camera);
            _shooting.Shoot();
        }
        else
        {
            _playerAnimator.ChangeMoveSpeed(_myAgent.velocity.magnitude);

            if (Input.GetMouseButtonDown(0))
            {
                var newDestination = _pathFinding.FindPath(_camera);

                if (newDestination != default)
                    _myAgent.SetDestination(newDestination);
            }
        }
    }

    public void StartShooting()
    {
        _isShootMode = true;
        _playerAnimator.StartAiming();
        _rig.weight = MaxRigWeight;
    }
}
