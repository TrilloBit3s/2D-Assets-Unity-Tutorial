using UnityEngine;

public class NeW_Player : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 5f;
    public float jumpHeight = 7f;
    public int maxJumps = 1;  // Número máximo de pulos, modifique conforme necessário

    [Header("References")]
    public Animator animator;
    public Rigidbody2D rb2D;
    public GroundCheck groundCheckScript;  // Referência ao script GroundCheck

    private float moviment;
    private bool facinRight = true;

    // Variáveis para controlar os pulos
    public int currentJumps = 0;  // Variável que mantém o número de pulos realizados

    private void Update()
    {
        moviment = Input.GetAxis("Horizontal");
        moviment = SimpleInput.GetAxis("Horizontal");

        bool isGrounded = groundCheckScript.IsGrounded();  // Usando o método IsGrounded do GroundCheck

        // Resetando o contador de pulos quando o jogador toca o chão
        if (isGrounded)
        {
            currentJumps = 0;  // Certifique-se de que o contador de pulos seja resetado ao tocar o chão
        }

        // Lógica para virar o personagem
        if (moviment < 0f && facinRight == true)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facinRight = false;
        }
        else if (moviment > 0f && facinRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facinRight = true;
        }

        // Lógica de animação de movimento
        if (Mathf.Abs(moviment) > .1f)
        {
            animator.SetFloat("Run", 1f);
        }
        else if (moviment < .1f)
        {
            animator.SetFloat("Run", 0f);
        }

        // Chama o método de pulo
        if (Input.GetButtonDown("Jump"))
        {
            JumpButton();
        }
    }

    private void FixedUpdate()
    {
        // Atualiza a posição do jogador com base na entrada horizontal
        transform.position += new Vector3(moviment, 0f, 0f) * Time.deltaTime * speed;

        // Atualiza a animação de velocidade vertical (pulo ou queda)
        animator.SetFloat("SpeedY", rb2D.velocity.y);
        animator.SetBool("IsGrounded", groundCheckScript.IsGrounded());  // Verifica se está no chão
    }

    public void AttackAnimation()
    {
        int randomAttack = Random.Range(0, 3);

        if (randomAttack == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else if (randomAttack == 1)
        {
            animator.SetTrigger("Attack2");
        }
        else
        {
            animator.SetTrigger("Attack3");
        }
    }

    public void JumpButton()
    {
        if (currentJumps < maxJumps)  // Verifica se o número de pulos não excedeu o limite
        {
            // Se o jogador está no segundo pulo, ativa a animação de double jump
            if (currentJumps == 1)
            {
                animator.SetTrigger("DoubleJump");
            }

            Vector2 velocity = rb2D.velocity;
            velocity.y = jumpHeight;
            rb2D.velocity = velocity;
            animator.SetTrigger("OnJump");

            currentJumps++;  
        }
        else
        {
            // Se o jogador já tiver pulado o máximo permitido, não permite pular
            return;
        }
    }
}


/*
//com groundCheck
using UnityEngine;

public class NeW_Player : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 5f;
    public float jumpHeight = 7f;

    [Header("References")]
    public Animator animator;
    public Rigidbody2D rb2D;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private float moviment;
    private bool isGrounded;
    private bool facinRight = true;

    private void Update()
    {
        moviment = Input.GetAxis("Horizontal");
        moviment = SimpleInput.GetAxis("Horizontal");
        isGrounded = CheckGroud();

        if (moviment < 0f && facinRight == true)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facinRight = false;
        }
        else if (moviment > 0f && facinRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facinRight = true;
        }

        if (Mathf.Abs(moviment) > .1f)
        {
            animator.SetFloat("Run", 1f);
        }
        else if (moviment < .1f)
        {
            animator.SetFloat("Run", 0f);
        }
    }

    private bool CheckGroud()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        // Atualiza a posição do jogador com base na entrada horizontal
        transform.position += new Vector3(moviment, 0f, 0f) * Time.deltaTime * speed;

        // Atualiza a animação de velocidade vertical (pulo ou queda)
        animator.SetFloat("SpeedY", rb2D.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void AttackAnimation()
    {
        int randomAttack = Random.Range(0, 3);

        if (randomAttack == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else if (randomAttack == 1)
        {
            animator.SetTrigger("Attack2");
        }
        else
        {
            animator.SetTrigger("Attack3");
        }
    }

    public void JumpButton()
    {
        if (isGrounded)
        {
            Vector2 velocity = rb2D.velocity;
            velocity.y = jumpHeight;
            rb2D.velocity = velocity;
            animator.SetTrigger("OnJump");
        }
    }
}
*/