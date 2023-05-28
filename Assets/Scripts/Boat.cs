using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public GameObject followPlayer;
    public float degisken;

    public float distanceX;
    public float distanceZ;

    public float lerpSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(followPlayer.transform.position.x + distanceX,transform.position.y,followPlayer.transform.position.z -distanceZ),lerpSpeed);
        //transform.LookAt(followPlayer.traposition)
        transform.rotation =  Quaternion.Euler
        (transform.eulerAngles.x ,
         90 + ((followPlayer.transform.position.x - transform.position.x ) * degisken )
        ,transform.eulerAngles.z) ;

        //new Vector3(transform.position.x, followPlayer.transform.position.y , transform.position.z)
    }
}
