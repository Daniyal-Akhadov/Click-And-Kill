using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _damage = 1;

    private const float TimeToDie = 5f;

    private void Start()
    {
        Destroy(gameObject, TimeToDie);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.left, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
