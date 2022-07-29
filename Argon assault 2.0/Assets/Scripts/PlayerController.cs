using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 0.2f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 1.0f;


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

    }

    void ProcessRotation()
    {
      float pitchDueToPosition = transform.localPosition.y * positionPitchFactor ; //pitch from the position change
      float pithDueToControlflow = yThrow * controlPitchFactor; //pitch from the rotation change

      float pitch = pitchDueToPosition + pithDueToControlflow; // pitch 
      float yaw = transform.localPosition.x * positionYawFactor ;
      float roll = transform.localPosition.z * positionPitchFactor * 0f;
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
}
