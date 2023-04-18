using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(ReloadCurrentScene);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(ReloadCurrentScene);
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
