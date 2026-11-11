using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    public bool IsGrounded()
    {
        // Verifica se o jogador está tocando o chão
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}