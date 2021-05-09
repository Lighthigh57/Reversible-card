using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject disc;
    public int[,] boardinfo = new int[8, 8];//-1 null ,0 White, 1 Black 

    private readonly bool[,] boardcheck = new bool[8, 8];
    private readonly GameObject[,] disclist = new GameObject[8, 8];//y,x
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                boardinfo[i, j] = ((i * 8) + j) % 2;
                if (boardinfo[i, j] == 1)
                {
                    boardcheck[i, j] = true;
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                disclist[i, j] = Instantiate(disc, new Vector3(-3.5f + j, 0, 3.5f - i), Quaternion.identity);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int state = boardinfo[i, j];
                GameObject disc = disclist[i, j];
                if (state == 0)
                {
                    if (disc.activeSelf) disc.SetActive(false);
                }
                else
                {
                    if (!disc.activeSelf) disc.SetActive(true);
                }
                Debug.Log("state");
                disc.GetComponent<Disc>().reload(state);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boardinfo[i, j] = Random.Range(-1, 1);
                }
            }
        }
    }

}
