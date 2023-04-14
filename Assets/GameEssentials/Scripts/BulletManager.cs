using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Bullet[] _bulletTypes;
    [SerializeField] private Button _changeBulletButton;

    private int _activeBulletIndex = 0;

    private void OnEnable()
    {
        _changeBulletButton.onClick.AddListener(SwitchToNextBullet);
    }

    private void OnDisable()
    {
        _changeBulletButton.onClick.RemoveListener(SwitchToNextBullet);
    }

    public void SwitchToNextBullet()
    {
        _activeBulletIndex++;
        if (_activeBulletIndex >= _bulletTypes.Length)
        {
            _activeBulletIndex = 0;
        }
        Debug.Log(_activeBulletIndex);
    }

    public Bullet GetActiveBullet()
    {
        return _bulletTypes[_activeBulletIndex];
    }
}