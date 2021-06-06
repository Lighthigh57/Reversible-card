using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject disc;
    public int[,] boardinfo = new int[8, 8];//-1 null ,0 White, 1 Black 
    public GameObject Black, White, Board;

    private readonly bool[,] boardcheck = new bool[8, 8];
    private readonly GameObject[,] disclist = new GameObject[8, 8], Boardlist = new GameObject[8, 8];//y,x
    private Text Bltext, Whtext;

    // Start is called before the first frame update
    void Start()
    {
        Bltext = Black.GetComponent<Text>();
        Whtext = White.GetComponent<Text>();
        Vector3 put;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                put = new Vector3(-3.5f + j, 0, 3.5f - i);
                boardinfo[i, j] = -1;
                disclist[i, j] = Instantiate(disc, put, Quaternion.identity);
                Boardlist[i, j] = Instantiate(Board, put, Quaternion.identity);
            }
        }
        boardinfo[3, 3] = boardinfo[4, 4] = 0;
        boardinfo[3, 4] = boardinfo[4, 3] = 1;
        Checkit();
    }

    internal void TurnDisc(int x, int y)
    {
        boardinfo[x, y] = boardinfo[x, y] == 0 ? 1 : 0;
        Checkit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Checkit()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int state = boardinfo[i, j];
                GameObject disc = disclist[i, j];
                if (state == -1)
                {
                    if (disc.activeSelf)
                    {
                        disc.SetActive(false);
                    }
                }
                else
                {
                    if (!disc.activeSelf)
                    {
                        disc.SetActive(true);
                    }
                }
                disc.GetComponent<Disc>().Reload(state);
            }
        }
    }

}
