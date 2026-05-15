using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instancia;
    public float velocidadMovimiento = 1f;
    public PlayerStateMachine stateMachine;
    public Transform[] camino;
    public IdleState idleState;
    public WalkState walkState;
    [HideInInspector]
    public int pasosRestantes = 0;
    [HideInInspector]
    public int posicionPunto = 0;
    [HideInInspector]
    public bool mover = false;
    [HideInInspector]
    public Animator animator;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        stateMachine = new PlayerStateMachine();
        idleState = new IdleState(this, stateMachine);
        walkState = new WalkState(this, stateMachine);
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        transform.position = camino[posicionPunto].transform.position;
        stateMachine.ChangeState(idleState);
    }

    void Update()
    {
        if (mover)
        {
            Move();
        }
        stateMachine.Update();
    }

    private void Move()
    {
        if (pasosRestantes <= 0)
        {
            mover = false;
            return;
        }

        if (posicionPunto > camino.Length - 1)
        {
            return;
        }

        Transform target = camino[posicionPunto];
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            velocidadMovimiento * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) <= 0.01f)
        {
            transform.position = target.position;
            pasosRestantes--;

            if (pasosRestantes > 0)
            {
                posicionPunto++;
                bool detener = BoardManager.instance.VerificarCasilla(posicionPunto);
                if (detener)
                {
                    mover = false;
                }
            }
            else
            {
                mover = false;
            }
        }
        

    }

}
    