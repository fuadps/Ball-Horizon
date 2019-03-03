using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sceneManager;
    public float playerSpeed = 1500f;
    public float directionalSpeed = 10f;
    public AudioClip scoreUp;
    public AudioClip damage;
    public bool canControl;

    float moveHorizontal;
    float touch;
    Vector3 targetPos;

    public SwipeControl swipeControls;

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        if (canControl) { }
            moveHorizontal = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(transform.position.x + moveHorizontal, -2.5f, 2.5f), transform.position.y, transform.position.z), directionalSpeed * Time.deltaTime);
        #endif       

        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;

        //Mobile Control
        if (canControl)
        {

            if (swipeControls.SwipeLeft )
            {
                touch = -2.5f;
                targetPos.x += touch;
            }

            if (swipeControls.SwipeRight)
            {
                touch = 2.5f;
                targetPos.x += touch;
            }
               
        }

        if (transform.position.x != targetPos.x)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(targetPos.x, -2.5f, 2.5f), transform.position.y, transform.position.z), directionalSpeed * Time.deltaTime);

        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scoreup")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
        }
        if (other.gameObject.tag == "Triangle")
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Initialize>().GameOverButton();
        }
    }
}
