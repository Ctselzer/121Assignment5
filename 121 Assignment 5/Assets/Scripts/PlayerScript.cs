using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed = 10;
    public float torque;
    public Text scoreText;
    public Text jumpText;
    [SerializeField] private Animator playerAnimator;
    public ParticleSystem system;

    private int score = 0;
    private Rigidbody rb;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerAnimator.SetBool("Grounded", grounded);
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Mouse X");
        playerAnimator.SetFloat("MoveSpeed", moveZ);
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        rb.AddForce(transform.forward * speed * moveZ);
        rb.AddForce(transform.right * speed * moveX);
        rb.AddTorque(transform.up * torque * turn);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector3(0, 10, 0);
            jumpText.enabled = false;
        }

    }

    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Item"))
		{
            system.Play();
			other.gameObject.SetActive (false);

			score = score + 1;
            scoreText.text = "Score: " + score.ToString();
		}
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("TitleScene");
        }

    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

}
