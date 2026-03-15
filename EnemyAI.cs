using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float speed = 2.0f;
    public float attackRange = 1.5f;
    public int health = 100;
    public int damage = 20;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange) {
            Attack();
        } else {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer() {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void Attack() {
        // Implement attack logic here
        Debug.Log("Enemy attacks the player for " + damage + " damage!");
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        // Implement death logic here
        Debug.Log("Enemy has died.");
        Destroy(gameObject);
    }
}