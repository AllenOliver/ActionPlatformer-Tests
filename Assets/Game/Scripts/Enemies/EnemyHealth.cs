using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth;
    [ReadOnly] public int CurrentHealth;

    private bool hasBeenHit;

    [Button(ButtonSizes.Small)]
    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage()
    {
        if (!hasBeenHit)
        {
            hasBeenHit = true;
            CurrentHealth--;
            if (CurrentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(TakeHit(.15f));
            }
        }
    }

    private IEnumerator TakeHit(float delay)
    {
        yield return new WaitForSeconds(delay);
        hasBeenHit = false;
    }

    private void Die()

    {
        RippleManager.instance.Ripple(RippleTypes.RED_BURST, Camera.main.WorldToViewportPoint(transform.position));

        Destroy(gameObject);
    }
}