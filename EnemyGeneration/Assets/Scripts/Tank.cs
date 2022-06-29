using UnityEngine;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent _fired;
    private Vector2 _currentDirection;

    private Transform _tower;

    private void Awake()
    {
        _tower = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        TowerControl();

        if (Input.GetMouseButtonDown(0)) 
        {
            _fired?.Invoke();
        }
    }

    private void TowerControl() 
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = _tower.position;

        Vector2 direction = mousePosition - targetPosition;
        direction.Normalize();

        _currentDirection = Vector2.Lerp(_currentDirection, direction, _speed * Time.deltaTime);
        _tower.up = -_currentDirection;
    }
}
