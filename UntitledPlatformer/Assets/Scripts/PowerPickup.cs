using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerPickup : MonoBehaviour
{
    public int value;
    public int powerupType;
    public GameObject pickupEffect;
    public GameObject uiObject;

    public AudioSource pickupSound;

    bool hasbeenCollected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasbeenCollected==false)
        {
            hasbeenCollected = true;

            pickupSound.Play();

            FindObjectOfType<GameManager>().AddGold(value);
            FindObjectOfType<GameManager>().AddSecret();
            Instantiate(pickupEffect, transform.position, transform.rotation);

            
            //unlock double jump
            if (powerupType == 0)
            {
                PlayerController playerScript = other.GetComponent<PlayerController>();
                
                playerScript.maxjumps++;

                uiObject.GetComponent<Text>().text = "More Jumps Unlocked!";
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");

            }
            //unlock super speed
            if (powerupType == 1)
            {
                PlayerController playerScript = other.GetComponent<PlayerController>();

                playerScript.movespeed = playerScript.movespeed*1.5f;

                uiObject.GetComponent<Text>().text = "Super Speed Unlocked!";
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");

            }
            //unlock low gravity
            if (powerupType == 2)
            {
                PlayerController playerScript = other.GetComponent<PlayerController>();

                playerScript.gravityScale = playerScript.gravityScale * 0.4f;

                uiObject.GetComponent<Text>().text = "Low Gravity Unlocked!";
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");

            }
            //unlock super jump
            if (powerupType == 3)
            {
                PlayerController playerScript = other.GetComponent<PlayerController>();

                playerScript.jumpForce = playerScript.jumpForce * 1.5f;

                uiObject.GetComponent<Text>().text = "Super Jump Unlocked!";
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");

            }
            //unlock BIG frog
            if (powerupType == 4)
            {
                PlayerController playerScript = other.GetComponent<PlayerController>();

                playerScript.transform.localScale = new Vector3 (2,2,2);

                uiObject.GetComponent<Text>().text = "Super Frog Unlocked!";
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");

            }
        }
    }

    IEnumerator WaitForSec()

    {
        yield return new WaitForSeconds(3f);
        uiObject.SetActive(false);
        Destroy(gameObject);
    }

}
