using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    public GameObject PickUpText;
    public GameObject GunOnPlayer;

    private GunScript GS;

    //int magazineSize = 3;

    private void Start()
    {
        //GunOnPlayer.SetActive(false);
        PickUpText.SetActive(false);

        GS = GunOnPlayer.GetComponent<GunScript>();

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

                GS.ReloadGun();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
