using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    //assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //damage
    public int explosionDamage;
    public int explosionRange;
    public int explosionForce;

    //lifetime
    public int maxCollisions;
    public float maxLifeTime;
    public bool explosionOnTouch = true;

    int collisions;
    PhysicsMaterial physics_mat;

    private void Start()
    {
        SetUp();
    }

    private void Update()
    {
        if (collisions > maxCollisions) Explode();

        //countdown lifetime
        maxLifeTime -= Time.deltaTime;
        if (maxLifeTime <= 0) Explode();
    }

    private void Explode()
    {
        //instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //get component of enemy and call take damage
            //enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage);

        }

        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //don't count collissions with other bullets
        if (collision.collider.CompareTag("Bullet")) return;

        //count up collisions
        collisions++;

        //explode if bullet hits an enemy directly and explodeontouch is activated
        if (collision.collider.CompareTag("Enemy") && explosionOnTouch) Explode();
    }

    private void SetUp()
    {
        physics_mat = new PhysicsMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicsMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicsMaterialCombine.Maximum;

        //GetComponent<SphereCollider>().material = physics_mat;

        rb.useGravity = useGravity;
    }
}
