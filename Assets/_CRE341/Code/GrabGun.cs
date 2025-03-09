using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    public GameObject PickUpText;
    public GameObject GunOnPlayer;

    private void Start()
    {
        GunOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")

            PickUpText.SetActive(true);
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                this.gameObject.SetActive(false);

                GunOnPlayer.SetActive(true);

                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
