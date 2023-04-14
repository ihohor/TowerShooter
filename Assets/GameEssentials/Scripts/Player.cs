using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;


public class Player : MonoBehaviour
{
    [SerializeField] private TowerTrigger _towerTrigger;
    [SerializeField] private Camera _camera;
    [SerializeField] private Rig _rig;

    private AnimatorManager _animatorManager; 
    private NavMeshAgent _myAgent;
    private PathFinding _pathFinding;
    private Shooting _shooting;

    private bool _onTop = false;

    private void OnEnable()
    {
        _towerTrigger.PlayerEnteredTrigger += SetShootingMode;
    }

    private void OnDisable()
    {
        _towerTrigger.PlayerEnteredTrigger -= SetShootingMode;
    }

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _animatorManager = GetComponent<AnimatorManager>();
        _pathFinding = GetComponent<PathFinding>();
        _shooting = GetComponent<Shooting>();
    }

    private void Update()
    {
        _animatorManager.SetAnimationSpeed(_myAgent,_onTop);
        _pathFinding.FindPath(_myAgent,_onTop, _camera);
        _shooting.AimToMouse(_camera, _onTop);
        _shooting.Shoot(_onTop);
    }

    private void SetShootingMode()
    {
        _onTop = true;
        _animatorManager.SetAiming();
        _rig.weight = 1.0f;
    }
}
