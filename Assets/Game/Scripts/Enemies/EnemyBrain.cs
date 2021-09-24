using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyBrain : MonoBehaviour
{
    public EnemyHealth Health;
    public BoxCollider2D PhysicalCollider;
    public CircleCollider2D HitCollider;
    public Rigidbody2D PhysicsBody;
    public ParticleSystem HitParticles;
    public EnemyStats EnemyStats;

    // Start is called before the first frame update
    private void Start()
    {
        AssignComponents();

        if (EnemyStats)
        {
            Health.MaxHealth = EnemyStats.MaxHealth;
        }
    }

    [Button(ButtonSizes.Medium)]
    private void SetupEnemy()
    {
        gameObject.tag = "Enemy";
        if (!gameObject.GetComponent<EnemyHealth>()) gameObject.AddComponent<EnemyHealth>();
        if (!gameObject.GetComponent<BoxCollider2D>()) gameObject.AddComponent<BoxCollider2D>();
        if (!gameObject.GetComponent<Rigidbody2D>()) gameObject.AddComponent<Rigidbody2D>();
        if (!gameObject.GetComponent<CircleCollider2D>()) gameObject.AddComponent<CircleCollider2D>();
        AssignComponents();
        if (EnemyStats)
        {
            Health.MaxHealth = EnemyStats.MaxHealth;
        }
        HitCollider.isTrigger = true;
    }

    [Button(ButtonSizes.Small)]
    private void AssignComponents()
    {
        Health = gameObject.GetComponent<EnemyHealth>();
        PhysicalCollider = gameObject.GetComponent<BoxCollider2D>();
        PhysicsBody = gameObject.GetComponent<Rigidbody2D>();
        HitCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerWeapon"))
        {
            HitParticles.Play();
            Health.TakeDamage();
        }
    }
}