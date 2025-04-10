using UnityEngine;

public class PortalJump : MonoBehaviour
{
    public MapGenerator MapGenerator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            MapGenerator.LevelGenerator();
    }
}
