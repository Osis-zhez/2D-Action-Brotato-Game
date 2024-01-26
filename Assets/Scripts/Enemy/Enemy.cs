using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected float speed;
    [SerializeField] protected float timeBetweenAttacks;
    [SerializeField] protected int damage;

    protected Transform playerTransform;
    
    public virtual void Start()
    {
        playerTransform = GameObject.FindObjectOfType<PlayerMovement>().transform;
    }

}
