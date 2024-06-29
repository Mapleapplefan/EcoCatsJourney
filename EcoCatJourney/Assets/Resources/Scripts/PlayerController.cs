using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [Header("Player Settings")]
    public int Speed = 5;
    public float JumpForce = 1;

    [Header("Ground Checking")]
    public LayerMask GroundLayer = 0;

    private Rigidbody2D m_rigidbody;
    [HideInInspector] public Vector2 m_horizontalMovement;
    [HideInInspector] public bool m_grounded;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        m_horizontalMovement.x = Input.GetAxis("Horizontal");
        m_rigidbody.velocity = new Vector2(m_horizontalMovement.x * Speed, m_rigidbody.velocity.y);
        m_grounded = Physics2D.OverlapCircle(transform.position + new Vector3(0, -0.5f, 0), .1f, GroundLayer);
        Jump();
    }

    void Jump()
    {
        if (m_grounded && Input.GetKeyDown(KeyCode.Space)) {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, JumpForce);
        }
    }
}
