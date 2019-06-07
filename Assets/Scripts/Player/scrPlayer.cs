using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour
{
    #region Variaveis

    scrHealth Vida;
    public GameObject MenuPause;
    public AudioSource Jump;

    #region Variaveis de movimento horizontal
    Rigidbody2D RigidBody;
    public float VelocidadeMaxima;
    public float EixoX;
    public float aceleração;
    #endregion

    #region Variaveis de movimento vertical
    float VelY;
    bool NPulos = false;
    public bool NoChao;
    public LayerMask CamadaPisavel;
    public Transform LocalPe;
    public float ForcaPulo;
    public float radius;
    public float VeloY;
    #endregion 

    #endregion

    void Start () {
        RigidBody = GetComponent<Rigidbody2D>();
        Vida = GetComponent<scrHealth>();
	}

    void FixedUpdate()
    {
        #region Movimentação Vertical

        if (Input.GetButtonDown("Jump") && NoChao)
        {
            if (Jump)
            {
                Jump.Play();
            }
            RigidBody.AddForce( new Vector2(0f,ForcaPulo), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Jump") && !NoChao && NPulos)
        {
            if (Jump)
            {
                Jump.Play();
            }
            NPulos = false;
            RigidBody.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
        }

        VeloY = RigidBody.velocity.y;

        #endregion

        #region Movimentação Horizontal

        aceleração = EixoX * VelocidadeMaxima;
        RigidBody.velocity = new Vector2(aceleração * Time.deltaTime, RigidBody.velocity.y);

        #endregion

    }
	
	// Update is called once per frame
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPause.SetActive(true);
            Time.timeScale = 0f;
        }
        #region No Chao

        NoChao = Physics2D.OverlapCircle(LocalPe.transform.position,  radius , CamadaPisavel);

        if (NoChao == true)
        {
            NPulos = true;
        }

        #endregion

        #region Eixo X

        EixoX = Input.GetAxis("Horizontal");

        #endregion
    }
}
