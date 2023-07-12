using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] public float speedX;
    [SerializeField] public float speedY;
    [SerializeField] public float speedZ;

    // Update is called once per frame
    public void Update()
    {
        Rotation(speedX, speedY, speedZ);
    }

    public void Rotation(float rotationX, float rotationY, float rotationZ)
    {
        transform.Rotate(360 * rotationX * Time.deltaTime, 360 * rotationY * Time.deltaTime, 360 * rotationZ * Time.deltaTime); //full rotation per second
    }
}
