using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float stopDistance;
    [SerializeField] private float attackSpeed;

    private float attackTime;

    private void Update()
    {
         
        if(playerTransform != null) 
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            } 
            else 
            {

                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    IEnumerator Attack() 
    {
        playerTransform.GetComponent<PlayerHealth>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = playerTransform.position;
        
        float percent = 0f;
        while(percent <= 1) {

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;

        }

    }
}
