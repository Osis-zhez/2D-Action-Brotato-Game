using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject projectileVFXPrefab;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float damageAmount;

    private void Start() 
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        Instantiate(projectileVFXPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damageAmount);
            DestroyProjectile();
        }
    }
}
