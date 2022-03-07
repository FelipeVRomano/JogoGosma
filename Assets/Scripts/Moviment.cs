using UnityEngine;

public class Moviment : MonoBehaviour
{
    [SerializeField] GravityManager _gravityManager;
    
    [Header("Moviment Speed")]
    [SerializeField] float _speed = 5;
    [SerializeField] float _jumpForce;
    
    [Header("AudioSource")]
    [SerializeField] AudioClip[] _walkAudioClip;
    [SerializeField] AudioSource _walkSound;
    
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        HandleMovement();
        PlayWalkSound();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        _rigidbody2D.AddForce(new Vector2(direction.x * _speed, 0));
    }
    
    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.velocity += Vector2.up * _jumpForce;
    }

    void PlayWalkSound()
    {
        if (_gravityManager.IsGrounded && Input.GetAxis("Horizontal") > 0)
        {
            if (!_walkSound.isPlaying)
            {
                _walkSound.clip = _walkAudioClip[Random.Range(0, _walkAudioClip.Length)];
                _walkSound.Play();
            }
        }
    }
}
