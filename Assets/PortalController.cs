using UnityEngine;
using UnityEngine.AI;

public class PortalController : MonoBehaviour
{
    public GameObject portal;
    public float lengthOfTimeBeforePortalSpawn = 30.0f;
    private float timer = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lengthOfTimeBeforePortalSpawn)
        {
            timer += 1.0f * Time.deltaTime;
        }
        else if (timer >= lengthOfTimeBeforePortalSpawn)
        {
            timer = 0.0f;
            portal.SetActive(true);
        }

    }
}
