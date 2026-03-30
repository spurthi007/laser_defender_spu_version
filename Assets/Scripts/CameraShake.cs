using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 2f;
    [SerializeField] float shakeMagnitude = 0.5f;
    float initialDuration;
    Vector3 initialPosition;
    // Coroutine cameraShakeCoroutine;
    // float cameraShakeTime;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialDuration = shakeDuration;
        // cameraShakeTime = shakeDuration;
    }

    
    
    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {

        while (shakeDuration > 0)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle;
            //Debug.Log("The camerais shaking and transform.position is " + transform.position);
            shakeDuration -= Time.deltaTime;
            yield return null;
        }

        
        transform.position = initialPosition;
        shakeDuration = initialDuration;
       // cameraShakeCoroutine = null;
    }

    // IEnumerator Shake()
    // {
    //     float elapsedTime = 0;
    //     while(elapsedTime < shakeDuration)
    //     {
    //         transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
    //         elapsedTime += Time.deltaTime;
    //         yield return new WaitForEndOfFrame();
    //     }
    //     transform.position = initialPosition;
    // }

}
