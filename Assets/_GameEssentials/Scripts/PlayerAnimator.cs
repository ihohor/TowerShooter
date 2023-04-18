using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private MultiAimConstraint _bodyAim;

    private Animator _animator;

    private readonly int _speedAnimator = Animator.StringToHash("speed");
    private readonly int _shootMode = Animator.StringToHash("isShooting");

    private readonly float _maxRigWeight = 1f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeMoveSpeed(float speed)
    {
        _animator.SetFloat(_speedAnimator, speed);
    }

    public void StartAiming()
    {
        _animator.SetBool(_shootMode, true);
        _bodyAim.weight = _maxRigWeight;
    }

    public void StartRunning()
    {
        _animator.SetBool(_shootMode, false);
        _bodyAim.weight = 0f;
    }
}