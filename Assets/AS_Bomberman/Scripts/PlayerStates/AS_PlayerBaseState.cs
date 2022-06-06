using UnityEngine;

public abstract class AS_PlayerBaseState
{
    public abstract void EnterState(AS_PlayerController player);
    public abstract void Update(AS_PlayerController player);
    public abstract void OnCollisionEnter(AS_PlayerController player, Collision2D collision);
    public abstract void OnCollisionStay(AS_PlayerController player, Collision2D collision);
    public abstract void OnTriggerEnter(AS_PlayerController player, Collider2D collision);
    public abstract void OnTriggerExit(AS_PlayerController player, Collider2D collision);
}
