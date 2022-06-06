using UnityEngine;
using UnityEngine.SceneManagement;

public class tetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 18;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.LeftArrow))
         {
                transform.position += new Vector3(-1, 0, 0);
                if(!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }
         else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if(!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotate function
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            FindObjectOfType<AudioManager>().Play("blockPlace");
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                FindObjectOfType<AudioManager>().Play("blockPlace");

                this.enabled = false;
                FindObjectOfType<SpawnTeromino>().NewTetromino();
            }
            previousTime = Time.time;
        }
    }

    void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--) {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                FindObjectOfType<AudioManager>().Play("lineClear");
                LinesCleared.LinesClear += 1;
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
           if(grid[j,i] == null)
            {
                return false;
            }
        }

        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for(int y = i; y < height; y++) 
        {
            for(int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
        CheckEndGame();
    }

    void CheckEndGame()
    {
        // For every block in the column
        for (int j = 0; j < width; j++)
        {
            // Check to see if there are any blocks in the highest row
            if (grid[j, height-1] != null)
            {
                // If there are blocks at the top, the game is over
                GameOver();
            }
        }
    }

    void GameOver()
    {
        //FindObjectOfType<AudioManager>().Play();
        SceneManager.LoadScene("TetrisGameOver");
    }

    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0.5 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }
        return true;
    }
}
