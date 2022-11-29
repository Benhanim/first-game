using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject enemy;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject bullet;

    public float sightRange, attackRange, timeToLive;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && playerInSightRange)
            LookAtPlayer();
        else if (playerInAttackRange && playerInSightRange)
            AttackPlayer();
    }

    public virtual void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    public virtual void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            var cloneBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            Rigidbody rb = cloneBullet.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 100f, ForceMode.Impulse);

            Destroy(cloneBullet, timeToLive);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
            
    }

    public virtual void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}