using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AS_PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [Space]

    #region PlayerStats
    [SerializeField] private float playerSpeed = 2f;
    [SerializeField] private int bombMaxCapacity = 1;
    [SerializeField] private int bombMinCapacity = 1;
    [SerializeField] private int bombFireSize = 1;
    private bool isPlayerDead = false;
    [SerializeField]private bool isBombSpawned = false;

    public float PlayerSpeed 
    {
        get { return playerSpeed; }
        set { playerSpeed = value; }
    }
    public int BombMaxCapacity
    {
        get { return bombMaxCapacity; }
        set { bombMaxCapacity = value; }
    }
    public int BombMinCapacity
    {
        get { return bombMinCapacity; }
        set { bombMinCapacity = value; }
    }
    public int BombFireSize
    {
        get { return bombFireSize; }
        set { bombFireSize = value; }
    }
    public bool IsPlayerDead
    {
        get { return isPlayerDead; }
        set { isPlayerDead = value; }
    }
    public bool IsBombSpawned
    {
        get { return isBombSpawned; }
        set { isBombSpawned = value; }
    }
    #endregion

    private new Rigidbody2D rigidbody2D;
    private Transform target;
    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }
    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get { return agent; }
        set { agent = value; }
    }

    private AS_PlayerBaseState currentState;
    public AS_PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly AS_PlayerIdleState IdleState = new AS_PlayerIdleState();
    public readonly AS_PlayerMovingState MovingState = new AS_PlayerMovingState();
    public readonly AS_EnemyAggressiveState AggressiveState = new AS_EnemyAggressiveState();
    public readonly AS_EnemyDefensiveState DefensiveState = new AS_EnemyDefensiveState();

    [Space]
    [SerializeField] private string positionTrigger;
    public string PositionTrigger
    {
        get { return positionTrigger; }
        set { positionTrigger = value; }
    }

    public float timePassed = 0;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        PositionTrigger = "";

        TransitionToState(IdleState);

        if (gameObject.CompareTag("Enemy"))
        {
            TransitionToState(AggressiveState);
        }
        BombMinCapacity = BombMaxCapacity;
    }

    private void Update()
    {
        currentState.Update(this);
        timePassed += Time.deltaTime;

        if (BombMinCapacity > BombMaxCapacity)
        {
            BombMinCapacity = BombMaxCapacity;
        }

        if (timePassed >= 7f)
        {
            timePassed = 0f;
        }

    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + MovingState.movement * PlayerSpeed * Time.deltaTime);
    }

    public void TransitionToState(AS_PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        currentState.OnCollisionStay(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter(this, collision);
    }

    public void SpawnBomb()
    {
        float bombX = Mathf.Ceil(gameObject.transform.position.x) - 0.5f;
        float bombY = Mathf.Ceil(gameObject.transform.position.y) - 0.5f;
        Vector2 bombPos = new Vector2(bombX, bombY);

        Instantiate(bomb, bombPos, Quaternion.identity);
        bomb.GetComponent<CircleCollider2D>().enabled = false;
    }
}