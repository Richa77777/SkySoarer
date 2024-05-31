using UnityEngine;

public class DestroyObstacleZone : MonoBehaviour
{
    [SerializeField] private ObjectPool _obstaclePool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObstacleTrigger"))
        {
            _obstaclePool.ReturnObject(collision.gameObject);
        }
    }
}