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
                Debug.Log(i * 8 + j);
                if (boardinfo[i, j] == 0)
                {
                    boardcheck[i, j] = true;
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                disclist[i, j] = Instantiate(disc, new Vector3(-3.5f + j, 0.1f, 3.5f - i), Quaternion.identity);
            }
        }
        Checkboard();
    }

    private void Checkboard()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (boardcheck[i, j])
                {
                    GameObject target = disclist[i, j];
                    if (boardinfo[i, j] < 0)
                    {
                        target.SetActive(false);
                    }
                    else
                    {
                        target.SetActive(true);
                        target.GetComponent<Transform>().Rotate(180, 0, 0);
                    }
                    boardcheck[i, j] = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checkboard();
    }
}
