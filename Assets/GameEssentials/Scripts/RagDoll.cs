using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _mainCollider;
    [SerializeField] private GameObject _rig;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _mainRigitBody;

    private Collider[] _ragDollColliders;
    private Rigidbody[] _rigidBodies;

    private readonly string _bulletTag = "Bullet";

    private void Start()
    {
        GetRagDollParts();
        SwitchRagDoll(true, false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == _bulletTag)
            SwitchRagDoll(false, true);
    }

    private void GetRagDollParts()
    {
        _ragDollColliders = _rig.GetComponentsInChildren<Collider>();
        _rigidBodies = _rig.GetComponentsInChildren<Rigidbody>();
    }

    private void SwitchRagDoll(bool isFalseForRag, bool isTrueForRag)
    {
        _animator.enabled = isFalseForRag;

        foreach (Collider col in _ragDollColliders)
        {
            col.enabled = isTrueForRag;
        }
        foreach (Rigidbody rigit in _rigidBodies)
        {
            rigit.isKinematic = isFalseForRag;
        }

        _mainCollider.enabled = isFalseForRag;
        _mainRigitBody.isKinematic = isTrueForRag;
    }
}
