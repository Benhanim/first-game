using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : NormalEnemy
{
    public GameObject sniperBullet;

    public override void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            var cloneBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            Rigidbody rb = cloneBullet.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 550f, ForceMode.Impulse);

            Destroy(cloneBullet, timeToLive);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
}
