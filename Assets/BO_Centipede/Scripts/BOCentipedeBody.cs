using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOCentipedeBody : MonoBehaviour
{
    public SpriteRenderer spriteRender { get; private set; }
    public BOCentipedeSpawn centipede { get; set; }
    public BOCentipedeBody ahead { get; set; }
    public BOCentipedeBody behind { get; set; }
    public bool isHead => ahead == null;

    Vector2 direction = Vector2.right + Vector2.down;
    Vector2 targetPosition;

    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
    }

    void Update()
    {
        if(isHead && Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            UpdateHeadSegment();
        }

        Vector2 currentPosition = transform.position;
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, centipede.speed * Time.deltaTime);

        Vector2 movementDirection = (targetPosition - currentPosition).normalized;
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void UpdateHeadSegment()
    {
        Vector2 gridposition = GridPosition(transform.position);

        targetPosition = gridposition;
        targetPosition.x += direction.x;

        if(Physics2D.OverlapBox(targetPosition, Vector2.zero, 0f, centipede.collisionMask))
        {
            direction.x = -direction.x;

            targetPosition.x = gridposition.x;
            targetPosition.y = gridposition.y + direction.y;

            Bounds homeBounds = centipede.homeArea.bounds;

            if((direction.y == 1f && targetPosition.y > homeBounds.max.y) || (direction.y == -1f && targetPosition.y < homeBounds.min.y))
            {
                direction.y = -direction.y;
                targetPosition.y = gridposition.y + direction.y;
            }


        }

        if(behind != null)
        {
            behind.UpdateBodySegment();
        }
    }

    void UpdateBodySegment()
    {
        targetPosition = GridPosition(ahead.transform.position);
        direction = ahead.direction;

        if (behind != null)
        {
            behind.UpdateBodySegment();
        }
    }
    Vector2 GridPosition(Vector2 position)
    {
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        return position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            centipede.Remove(this);
        }
    }
}
