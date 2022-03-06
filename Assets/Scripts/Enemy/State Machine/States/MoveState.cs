using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        if (Target != null)
        {
            var playerPositionX = new Vector2(Target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerPositionX, _speed * Time.deltaTime);
        }
    }
}
