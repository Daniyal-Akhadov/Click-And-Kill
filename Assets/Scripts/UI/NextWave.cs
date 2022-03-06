using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Button _nextWaveButton;

    private Spawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.AllEnemiesSpawned += OnAllEnemiesSpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemiesSpawned -= OnAllEnemiesSpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemiesSpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClick()
    {
        _spawner.SetNextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
