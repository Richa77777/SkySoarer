using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _tiltAngle = 25f; // Угол наклона
    [SerializeField] private float _tiltSpeed = 5f; // Скорость изменения угла
    [SerializeField] private float _smoothTime = 0.3f; // Время сглаживания угла

    private Rigidbody2D _rb;
    private float _currentVelocity;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        // Изменение наклона в зависимости от вертикальной скорости
        float targetAngle = _rb.velocity.y > 0 ? _tiltAngle : -_tiltAngle;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref _currentVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Border"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
