using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] float camaraSpeed;
    private Vector3 _camaraOffset;
    [SerializeField] Transform PlayerTransform;
    float SmoothFactor = 0.5f;
    [SerializeField] bool LookAtPlayer = false;
    [SerializeField] bool RotateAroundPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        _camaraOffset = transform.position - PlayerTransform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * camaraSpeed, Vector3.up);
            _camaraOffset = camTurnAngle * _camaraOffset;
        }
        
        Vector3 newPos = PlayerTransform.position + _camaraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if(LookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
