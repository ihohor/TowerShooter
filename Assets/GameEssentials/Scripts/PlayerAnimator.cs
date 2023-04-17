using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private readonly int _speedAnimator = Animator.StringToHash("speed");
    private readonly int _shootMode = Animator.StringToHash("OnTop");

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
    }
}