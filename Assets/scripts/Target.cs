using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isTargetPractice = true;
    public float health = 10f;
    public float defaultHealth;

    private void Start()
    {
        defaultHealth = health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log($"Target took {amount} damage. Remaining health: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Target Broken");

        if (isTargetPractice)
        {
            health = defaultHealth;

            //respawn at new position
            Vector3 newPosition = new Vector3(
                Random.Range(-7f, 7f),
                Random.Range(-3f, 3f),
                34.38f
            );
            transform.position = newPosition;

            TargetMover mover = GetComponent<TargetMover>();
            if (mover != null)
            {
                mover.ResetPath();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}



