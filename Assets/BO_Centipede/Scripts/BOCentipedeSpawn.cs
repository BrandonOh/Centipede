using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOCentipedeSpawn : MonoBehaviour
{
    public List<BOCentipedeBody> segments = new List<BOCentipedeBody>();

    public BOCentipedeBody centipedeBody;
    public BOMushroomEnv mushroom;
    public GameObject score;

    public Sprite headCentipede;
    public Sprite bodyCentipede;

    public int size = 12;
    public float speed = 20f;
    public LayerMask collisionMask;
    public BoxCollider2D homeArea;

    void Start()
    {
        Respawn();
    }

    void Update()
    {
        if ( GameObject.FindGameObjectsWithTag("Centipede").Length == 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        foreach(BOCentipedeBody segment in segments)
        {
            Destroy(segment.gameObject);
        }

        segments.Clear();

        for(int i = 0; i < size; i++)
        {
            Vector2 position = GridPosition(transform.position) + (Vector2.left * i);
            BOCentipedeBody segment = Instantiate(centipedeBody, position, Quaternion.identity);
            segment.spriteRender.sprite = i == 0 ? headCentipede : bodyCentipede;
            segment.centipede = this;
            segments.Add(segment);
        }

        for(int i = 0; i < segments.Count; i++)
        {
            BOCentipedeBody segment = segments[i];
            segment.ahead = GetSegmentAt(i - 1);
            segment.behind = GetSegmentAt(i + 1);
        }
    }

    public void Remove(BOCentipedeBody segment)
    {
        Vector3 position = GridPosition(segment.transform.position);
        Instantiate(mushroom, position, Quaternion.identity);

        if (segment.ahead != null)
        {
            segment.ahead.behind = null;
        }

        if(segment.behind != null)
        {
            segment.behind.ahead = null;
            segment.behind.spriteRender.sprite = headCentipede;
            segment.behind.UpdateHeadSegment();
        }

        score.GetComponent<BOScore>().AddPoints(100);
        segments.Remove(segment);
        Destroy(segment.gameObject);
    }

    BOCentipedeBody GetSegmentAt(int index)
    {
        if(index >= 0 && index < segments.Count)
        {
            return segments[index];
        }
        else
        {
            return null;
        }
    }
    Vector2 GridPosition(Vector2 position)
    {
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        return position;
    }
}
