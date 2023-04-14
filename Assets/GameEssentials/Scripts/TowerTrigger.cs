using System;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    private readonly string _playerTag = "Player";

    public event Action PlayerEnteredTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
            PlayerEnteredTrigger?.Invoke();
    }
}
