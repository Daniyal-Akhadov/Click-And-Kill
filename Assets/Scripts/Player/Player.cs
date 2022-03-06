using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _initialHealth = 100;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;

    private void Awake()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _initialHealth;
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if (_animator == null)
        {
            throw new System.Exception("You don't have animator in child object!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }
    public void AddMoney(int reward)
    {
        Money += reward;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth, _initialHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
