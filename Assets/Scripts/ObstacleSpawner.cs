using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _obstaclePool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BackgroundController _backgroundController;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _maxHeight = 2f;

    private float _nextSpawn = 0f;

    private void Awake()
    {

        switch (PlayerPrefs.GetInt("Difficulty", 0))
        {
            case 0:
                _speed = 4f;
                _spawnRate = 2f;
                _backgroundController.SetScrollSpeed(3f);
                break;
            case 1:
                _speed = 6f;
                _spawnRate = 1.5f;
                _backgroundController.SetScrollSpeed(4f);
                break;
            case 2:
                _speed = 8f;
                _spawnRate = 1f;
                _backgroundController.SetScrollSpeed(5f);
                break;
        }
    }

    private void Update()
    {
        if (Time.time > _nextSpawn)
        {
            SpawnObstacle();
            _nextSpawn = Time.time + _spawnRate;
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = _obstaclePool.GetObject();

        float spawnY = Random.Range(-_maxHeight, _maxHeight);
        obstacle.transform.position = new Vector3(_spawnPoint.position.x, spawnY, _spawnPoint.position.z);

        Rigidbody2D obstacleRb = obstacle.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = Vector2.left * _speed;
    }
}
