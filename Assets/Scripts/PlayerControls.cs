using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    [SerializeField]float controlSpeed=30f;
    [SerializeField]float xRange=5f;
    [SerializeField]float yRange=5f;
    [SerializeField] float positionPitchFactor= -2f;
    [SerializeField] float controlPitchFactor= -15f;
    [SerializeField] float positionYawFactor= 2f;

     [SerializeField] float controlRawfactor= -3f;
    float xThrow;
    float yThrow;

    // Start is called before the first frame update
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
        float pitchDuetoPosition=transform.localPosition.y*positionPitchFactor;
        float pitchDuetoControlThrow=yThrow * controlPitchFactor ;


        float Pitch=pitchDuetoPosition + pitchDuetoControlThrow ;

        float Yaw=transform.localPosition.x* positionYawFactor;


        
        float roll=transform.localPosition.x*controlRawfactor;

       transform.localRotation=Quaternion.Euler(Pitch,Yaw,roll);
    }

    private void ProcessTranslation()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;


        float yOffset = yThrow * Time.deltaTime * controlSpeed;


        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYpos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
