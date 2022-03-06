using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootPoint)
    {   
        Instantiate(Bullet.gameObject, shootPoint.position, Quaternion.identity);
    }
}
