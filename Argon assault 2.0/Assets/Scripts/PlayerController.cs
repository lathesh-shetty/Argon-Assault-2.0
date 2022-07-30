using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] GameObject[] lasers;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlYawFactor = 20;


    float xThrow;
    float yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      ProcessTranslation();
      ProcessRotation();
      ProcessFiring();
    }

    void ProcessRotation()
    {
      float pitchDueToPosition = transform.localPosition.y * positionPitchFactor ; //pitch from the position change
      float pithDueToControlflow = yThrow * controlPitchFactor; //pitch from the rotation change



      float pitch = pitchDueToPosition + pithDueToControlflow; // pitch 
      float yaw =   transform.localPosition.x * positionYawFactor ;
      float roll = xThrow * controlYawFactor;
      
      transform.localRotation = Quaternion.Euler(pitch , yaw ,roll);
    }

    void ProcessTranslation()
    {
      xThrow = Input.GetAxis("Horizontal");
      yThrow = Input.GetAxis("Vertical");
    
      
      float xOffset = xThrow * Time.deltaTime * controlSpeed;
      float rawXPos = transform.localPosition.x + xOffset;
      float clampedXPos = Mathf.Clamp(rawXPos,-xRange,xRange);

      float yOffset = yThrow * Time.deltaTime * controlSpeed;
      float rawYPos = transform.localPosition.y + yOffset;
      float clampedYPos = Mathf.Clamp(rawYPos,-yRange,yRange);

      transform.localPosition = new Vector3 (clampedXPos,clampedYPos,transform.localPosition.z);
    }

    void ProcessFiring()
    {
      if(Input.GetButton("Fire1"));
        {
            Activatelasers();
        }
        else
        {
            Deactivatelaser();
        }
    }

    void Activatelasers()
    {

    }

    void Deactivatelaser()
    {

    }
}
