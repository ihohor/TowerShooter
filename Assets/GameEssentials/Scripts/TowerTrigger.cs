using GameEssentials.Scripts;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IShootingman shootingman))
            shootingman.StartShooting();
    }
}
