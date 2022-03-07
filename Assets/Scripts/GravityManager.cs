using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [Header("Ground Check")]
    public Character characterJump;
    public float groundedRadius = 4f;
    public LayerMask groundedLayerMask;
    public Transform checkGround;
    
    public bool IsGrounded => _isGrounded;
    
    [Header("AudioSource")]
    [SerializeField] AudioSource _jumpSound;
    
    float _gravityForceY;
    bool _isGrounded;
    
    void Start()
    {
        _gravityForceY = -1;
        checkGround = GetComponent<Transform>();
    }
    
    void Update()
    {
        GroundedCheck();
        ChangeGravity();
    }

    void GroundedCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(checkGround.position, groundedRadius, groundedLayerMask);
    }

    bool CanChangeGravity()
    {
        return _isGrounded && Input.GetButtonDown("Jump");
    }
    
    void ChangeGravity()
    {
        if (CanChangeGravity())
        {
            _jumpSound.Play();
            characterJump.JumpForAll();
            characterJump.ChangeGravity(_gravityForceY);
            _gravityForceY *= -1;
        }
    }
}
