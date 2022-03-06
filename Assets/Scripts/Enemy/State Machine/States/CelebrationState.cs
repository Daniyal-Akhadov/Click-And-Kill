using UnityEngine;

public class CelebrationState : State
{
    private Animator _animator;

    private const string CelebrationAnimationKey = "Celebration";

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

    private void OnEnable()
    {
        _animator.Play(CelebrationAnimationKey);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
