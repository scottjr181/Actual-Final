using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject PatrolPoint;
    public GameObject target;
    private Animator AnimEnemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponent<NavMeshAgent>();
        enemy.SetDestination(PatrolPoint.transform.position);

        AnimEnemy = this.GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.transform.position);
        float Speed = enemy.velocity.z;
        //AnimEnemy.SetFloat("Speed", Mathf.Abs(enemy.velocity.magnitude));
        if(enemy.remainingDistance <= enemy.stoppingDistance)
        {
            AnimEnemy.SetBool("canAttack", true);
        }
        else
        {
            AnimEnemy.SetBool("canAttack", false);
        }
    }
}
