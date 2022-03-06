using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _rangeToAttack;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _rangeToAttack += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(Target.transform.position, transform.position) < _rangeToAttack)
            {
                NeedTransit = true;
            }
        }
        else
        {
            NeedTransit = true;
        }
    }
}
