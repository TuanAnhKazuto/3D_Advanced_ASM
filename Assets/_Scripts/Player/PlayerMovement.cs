using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    PauseGame pauseGame;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    [SerializeField] private Animator mainCamAnim;
    [SerializeField] private AudioSource footAudio;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource landAudio;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        mainCamAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        footAudio = GameObject.Find("playerFootStep").GetComponent<AudioSource>();
        jumpAudio = GameObject.Find("playerJumpUp").GetComponent<AudioSource>();
        landAudio = GameObject.Find("playerLand").GetComponent<AudioSource>();

        pauseGame = GameObject.Find("GameManager").GetComponent<PauseGame>();
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        mainCamAnim.SetFloat("Speed", move.magnitude);
        if (move.magnitude > 0 && isGrounded && !pauseGame.isPaused)
        {
            if (!footAudio.isPlaying)
            {
                footAudio.Play();
            }
        }
        else
        {
            if (move.magnitude < 1 || pauseGame.isPaused)
            {
                footAudio.Stop();
            }
        }
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            if (!jumpAudio.isPlaying)
            {
                jumpAudio.Play();
            }
        }
    }
}
