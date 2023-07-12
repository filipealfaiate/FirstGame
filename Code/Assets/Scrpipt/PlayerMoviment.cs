using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    Rigidbody playerRB;
    [SerializeField] float jumpHight = 5f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource killEnemySound;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector3( horizontalInput * moveSpeed, playerRB.velocity.y, verticalInput * moveSpeed);

        if (Input.GetButtonDown("Jump") && GroungCheck())
        {
            Jump(jumpHight);
        }
    }

    void Jump(float hight)
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, hight, playerRB.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            killEnemySound.Play();
            Destroy(collision.transform.parent.gameObject);
            Jump(2f);
        }
    }

    bool GroungCheck()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }    
}
