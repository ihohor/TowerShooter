using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _bullets;
    [SerializeField] private Button _changeBulletButton;

    public GameObject[] Bullets => _bullets;

    private int _activeBulletIndex = 0;

    private void OnEnable()
    {
        _changeBulletButton.onClick.AddListener(ChangeBulletType);
    }

    private void OnDisable()
    {
        _changeBulletButton.onClick.RemoveListener(ChangeBulletType);
    }

    private void ChangeBulletType()
    {
        _activeBulletIndex++;
        if (_activeBulletIndex >= _bullets.Length)
            _activeBulletIndex = 0;
    }

    public GameObject GetActiveBullet()
    {
        return _bullets[_activeBulletIndex];
    }
}