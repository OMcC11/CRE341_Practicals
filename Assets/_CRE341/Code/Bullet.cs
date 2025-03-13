using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.CompareTag("NPC"))
        {
            Destroy(collision.gameObject);
        }
    }
}
