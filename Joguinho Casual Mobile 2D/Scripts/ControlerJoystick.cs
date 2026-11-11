
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerJoystick : MonoBehaviour
{
    Rigidbody2D _personagem;
    public float _velocidade = 15;
    public float _velocidadeDePulo = 5;
    private float horizontalMove;
    bool _estaNoChao;
    bool _podePuloDuplo;
    bool _virandoRosto = true;
    public float delaySegundoPulo;
    bool moverEsquerda;
    bool moverDireita;

    private Animator _animator; 

    void Start()
    {
        _personagem = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); 
        moverEsquerda = false;
        moverDireita = false;
    }

    //Método chamado quando o botão esquerdo é pressionado
    public void PointerDownleft()
    {
        moverEsquerda = true;
    }

    //Método chamado quando o botão esquerdo é liberado
    public void PointerUpleft()
    {
        moverEsquerda = false;
    }

    //Método chamado quando o botão direito é pressionado
    public void PointerDownRight()
    {
        moverDireita = true;
    }

    //Método chamado quando o botão direito é liberado
    public void PointerUpRight()
    {
        moverDireita = false;
    }

    void FixedUpdate()
    {
        horizontalMove = 0;

        // Lógica para movimento horizontal
        if (moverEsquerda)
        {
            horizontalMove = -_velocidade;
        }

        if (moverDireita)
        {
            horizontalMove = _velocidade;
        }

        // Atualiza a velocidade do Rigidbody2D
        _personagem.velocity = new Vector2(horizontalMove, _personagem.velocity.y);

        // Controle da direção do personagem (virando para a esquerda ou direita)
        if (_virandoRosto == false && horizontalMove > 0)
        {
            OlhandoParaOsLados();
        }
        else if (_virandoRosto == true && horizontalMove < 0)
        {
            OlhandoParaOsLados();
        }

        // Atualiza as animações
        AtualizarAnimacoes();
    }

    void OlhandoParaOsLados()
    {
        _virandoRosto = !_virandoRosto;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Verifica se o personagem colidiu com o chão
        if (other.gameObject.CompareTag("chao"))
        {
            _estaNoChao = true;
            _podePuloDuplo = false;
        }
    }

    public void JumpButton()
    {
        // Verifica se o personagem está no chão ou se pode pular novamente (pulo duplo)
        if (_estaNoChao)
        {
            _estaNoChao = false;
            _personagem.velocity = Vector2.up * _velocidadeDePulo; // Aplica uma força para o pulo
            Invoke("EnableDoubleJump", delaySegundoPulo);
        }
        else if (_podePuloDuplo)
        {
            _personagem.velocity = Vector2.up * _velocidadeDePulo; // Pulo duplo
            _podePuloDuplo = false;
        }
    }

    void EnableDoubleJump()
    {
        // Permite o pulo duplo
        _podePuloDuplo = true;
    }

    // Função para atualizar as animações
    void AtualizarAnimacoes()
    {
        // Verifica a direção do movimento horizontal
        if (horizontalMove != 0 && _estaNoChao)
        {
            // Ativa a animação de correr
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isIdle", false);   // Desativa a animação de idle
        }
        else
        {
            // Desativa a animação de correr
            _animator.SetBool("isRunning", false);
        }

        // Se o personagem está no ar (pulando)
        if (!_estaNoChao)
        {
            _animator.SetBool("isJumping", true);  // Ativa a animação de pulo
        }
        else
        {
            _animator.SetBool("isJumping", false); // Desativa a animação de pulo
        }

        // Se o personagem está parado no chão (idle)
        if (horizontalMove == 0 && _estaNoChao)
        {
            _animator.SetBool("isIdle", true);    // Ativa a animação de idle
            _animator.SetBool("isRunning", false); // Desativa a animação de correr
        }
        else
        {
            _animator.SetBool("isIdle", false);   // Desativa a animação de idle
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerJoystick : MonoBehaviour
{
    Rigidbody2D _personagem;
    public float _velocidade = 15;
    public float _velocidadeDePulo = 5;
    private float horizontalMove;
    bool _estaNoChao;
    bool _podePuloDuplo;
    bool _virandoRosto = true;
    public float delaySegundoPulo;
    bool moverEsquerda;
    bool moverDireita;

    void Start()
    {
        _personagem = GetComponent<Rigidbody2D>();
        moverEsquerda = false;
        moverDireita = false;
    }

    //Método chamado quando o botao esquerdo é pressionado
    public void PointerDownleft()
    {
        moverEsquerda = true;
    }

    //Método chamado quando o botao esquerdo é liberado
    public void PointerUpleft()
    {
        moverEsquerda = false;
    }
        
    //Método chamado quando o botao direito é pressionado
    public void PointerDownRight()
    {
        moverDireita = true;
    }

    //Método chamado quando o botao direito é liberado
    public void PointerUpRight()
    {
        moverDireita = false;
    }


    void FixedUpdate()
    {
        horizontalMove = 0;

        if(moverEsquerda)
        {
            horizontalMove = -_velocidade;
        }

        if(moverDireita)
        {
            horizontalMove = _velocidade;
        }

        _personagem.velocity = new Vector2(horizontalMove, _personagem.velocity.y);

        if(_virandoRosto == false  && horizontalMove > 0)
        {
            OlhandoParaOsLados();
        }
        else if(_virandoRosto == true  && horizontalMove < 0)
        {
            OlhandoParaOsLados();
        }
    }

    void OlhandoParaOsLados()
    {
        _virandoRosto = !_virandoRosto;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("chao"))
        {
            _estaNoChao = true;
            _podePuloDuplo = false;            
        }
    }

    public void JumpButton()
    {
        if(_estaNoChao)
        {
            _estaNoChao = false;
            _personagem.velocity = Vector2.up * _velocidadeDePulo; // aplica uma força para o pulo
            Invoke("EnableDoubleJump", delaySegundoPulo);
        }
        else if(_podePuloDuplo)// verifica se o pulo duplo é possivel
        {
            _personagem.velocity = Vector2.up * _velocidadeDePulo;
            _podePuloDuplo = false;
        }
    }

    void EnableDoubleJump()
    {
        _podePuloDuplo = true;
    }
}