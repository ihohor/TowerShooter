using UnityEngine;
using UnityEngine.AI;

public class AnimatorManager : MonoBehaviour
{
    private Animator _animator;

    private readonly int _speedAnimator = Animator.StringToHash("speed");
    private readonly int _boolOnTop = Animator.StringToHash("OnTop");

    private float _speed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimationSpeed(NavMeshAgent agent,bool onTop)
    {
        if (!onTop)
        {
                _speed = agent.velocity.magnitude;
                _animator.SetFloat(_speedAnimator, _speed);
        }
    }
    public void SetAiming()
    {
        _animator.SetBool(_boolOnTop, true);
    }
}
