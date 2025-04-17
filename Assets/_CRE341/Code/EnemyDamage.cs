using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;
    //public int damage = 1;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(1);
        }
    }
}
