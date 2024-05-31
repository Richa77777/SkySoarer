using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _obstaclePool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _maxHeight = 2f;

    private float _nextSpawn = 0f;

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
