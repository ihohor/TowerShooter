using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _mainCollider;
    [SerializeField] private GameObject _rig;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _mainRigitBody;

    [SerializeField] private List<Collider> _ragDollColliders;
    [SerializeField] private List<Rigidbody> _rigidBodies;

    [SerializeField] private bool _findRagdollComponents;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_findRagdollComponents)
        {
            _ragDollColliders.Clear();
            _rigidBodies.Clear();

            _ragDollColliders.AddRange(_rig.GetComponentsInChildren<Collider>());
            _rigidBodies.AddRange(_rig.GetComponentsInChildren<Rigidbody>());

            _findRagdollComponents = false;
        }
    }
#endif

    private void Start()
    {
        DisableRagdoll();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Bullet bullet))
            EnableRagdoll();
    }

    private void EnableRagdoll()
    {
        _animator.enabled = false;

        foreach (var collider in _ragDollColliders)
            collider.enabled = true;

        foreach (var rigidbody in _rigidBodies)
            rigidbody.isKinematic = false;

        _mainCollider.enabled = false;
        _mainRigitBody.isKinematic = true;
    }

    private void DisableRagdoll()
    {
        _animator.enabled = true;

        foreach (var collider in _ragDollColliders)
            collider.enabled = false;

        foreach (var rigidbody in _rigidBodies)
            rigidbody.isKinematic = true;

        _mainCollider.enabled = true;
        _mainRigitBody.isKinematic = false;
    }
}
