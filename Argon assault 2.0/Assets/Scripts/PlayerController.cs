using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 0.2f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;
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
      float pitch = 0f;
      float yaw = 0f;
      float roll =0f;
      transform.localRotation = Quaternion.Euler(-30f,30f,0f);
    }

    void ProcessTranslation()
    {
      float xThrow = Input.GetAxis("Horizontal");
      float yThrow = Input.GetAxis("Vertical");
    
      
      float xOffset = xThrow * Time.deltaTime * controlSpeed;
      float rawXPos = transform.localPosition.x + xOffset;
      float clampedXPos = Mathf.Clamp(rawXPos,-xRange,xRange);

      float yOffset = yThrow * Time.deltaTime * controlSpeed;
      float rawYPos = transform.localPosition.y + yOffset;
      float clampedYPos = Mathf.Clamp(rawYPos,-yRange,yRange);

      transform.localPosition = new Vector3 (clampedXPos,clampedYPos,transform.localPosition.z);
    }
}
