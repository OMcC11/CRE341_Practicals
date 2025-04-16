using UnityEngine;

public class PortalJump : MonoBehaviour
{
    public MapGenerator MapGenerator;
    private int NumOfJumps = 0;

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
            if (NumOfJumps < 3)
            {
                MapGenerator.LevelGenerator();
            }
            else
            {

            }
    }
}
