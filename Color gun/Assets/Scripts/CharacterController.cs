using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Скрипт отвечает за передвижение персонажа
    public static float Speed = 11f;
    public static float JumpForce = 10f;
    public static bool IsNextToBlueWall = false;
    public static float Horizontal;
    private bool _isFacingRight;
    private bool _jumpButtonFlag;

    private bool IsGrounded => Physics2D.OverlapCircle(groundCheck.position, 0.6f, groundLayer);

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AudioSource jumpSound;


    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        switch (IsGrounded)
        {
            case true when Input.GetKeyDown(KeyCode.W):
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                _jumpButtonFlag = true;
                jumpSound.Play();
                break;
            case false when Input.GetKeyUp(KeyCode.W) && _jumpButtonFlag:
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                _jumpButtonFlag = false;
                break;
            default:
            {
                if (rb.velocity.x < 1 && IsNextToBlueWall)
                    rb.velocity = new Vector2(rb.velocity.x, 6.8f);

                break;
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal * Speed, rb.velocity.y);
    }

    private void Flip()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var rotation = transform.rotation;

        transform.eulerAngles = mousePos.x < transform.position.x
            ? new Vector3(rotation.x, 180f, rotation.z)
            : new Vector3(rotation.x, 0f, rotation.z);
    }
}