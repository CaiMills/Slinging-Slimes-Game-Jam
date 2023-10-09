using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public GameObject GameOverScreen;
    public GameObject BabySlime;
    public GameObject QueenSlime;
    public SpriteRenderer sr;
    [SerializeField]
    GameObject CamPoint;
    float CamZoom = -2;

    

    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck; //To be able to detect the ground
    [SerializeField] private LayerMask groundLayer;

    GeneralSoundController soundController;

    public AudioClip slimeJumpSound;
    public AudioClip slimeLandSound;
    public AudioClip slimeConnectSound;
    public AudioClip grasslandMusic;
    public AudioSource source;
    public AudioSource LoopSource;
    private void Start()
    {
        soundController = GetComponent<GeneralSoundController>();
        LoopSource.PlayOneShot(grasslandMusic);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //animator.SetFloat("Speed", Mathf.Abs(horizontal)); //Mathf.abs makes it always positive
        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); //Longer the jump button is pressed, the higher the jump
            source.PlayOneShot(slimeJumpSound);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); //The jump becomes shorter depending on when the jump button was released
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer); //Creates an invisible circle beneath player to detect if they are on the ground
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip() //this is the function that flips the sprite (I still have yet to make this fully work :(
    {
        if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            sr.flipX = true;
        }
        if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BabySlime")
        {
            source.PlayOneShot(slimeConnectSound);
            Destroy(collision.gameObject); //Destroys the slime
            jumpingPower += 8f; //Adds Jumping Power with every slime collected
            Vector3 localScale = transform.localScale;
            transform.localScale += new Vector3(1F, 1f, 1f); //Increases Size when connecting with slime
            CamPoint.transform.position = CamPoint.transform.position += new Vector3(0, 0, CamZoom);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            source.PlayOneShot(slimeLandSound);
        }
        if (collision.gameObject.tag == "Queen")
        {
            SceneManager.LoadScene("Win");
        }
    }


}
