using UnityEngine;


public class AttackState : State
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _delay = 2f;

    private float _lastAttackTime;
    private Animator _animator;

    private const string AttackAnimationKey = "Attack";

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if (_animator == null)
        {
            throw new System.Exception("You don't have an Animator in Child Object!");
        }
    }

    private void Update()
    {
        if (_lastAttackTime <= 0f)
        {
            _lastAttackTime = _delay;
            Attack(Target);
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(AttackAnimationKey);

        if (target != null)
        {
            target.TakeDamage(_damage);
        }
    }
}
