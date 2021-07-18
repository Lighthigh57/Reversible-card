using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject disc;
    public int[,] boardinfo = new int[8, 8];//0 null ,-1 White, 1 Black 
    public GameObject Black, White, Board;

    private readonly GameObject[,] disclist = new GameObject[8, 8], Boardlist = new GameObject[8, 8];//y,x
    private Text Bltext, Whtext;
    private sbyte turn = 1;
    private bool pass;
    private readonly List<int>[,] table = new List<int>[8, 8];
    private readonly bool[,] boardcheck = new bool[8, 8];

    private void Start()
    {
        Bltext = Black.GetComponent<Text>();
        Whtext = White.GetComponent<Text>();
        Vector3 put;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                put = new Vector3(-3.5f + j, 0, 3.5f - i);//j = 横(x) i = 縦(y)
                boardinfo[i, j] = 0;
                disclist[i, j] = Instantiate(disc, put, Quaternion.identity);
                disclist[i, j].SetActive(false);
                Boardlist[i, j] = Instantiate(Board, put, Quaternion.identity);
            }
        }
        boardinfo[3, 3] = boardinfo[4, 4] = -1;
        boardinfo[3, 4] = boardinfo[4, 3] = 1;
        Checkit();
    }
    /// <summary>
    /// ディスク回転
    /// </summary>
    /// <param name="x">裏返すX</param>
    /// <param name="y">裏返すY</param>
    internal void TurnDisc(int x, int y)
    {
        if (!boardcheck[y, x])
        {
            return;
        }
        boardinfo[y, x] = turn;
        foreach (var dir in table[y, x])
        {
            int nx = (dir % 3) - 1, ny = (dir / 3) - 1, plasex = x, plasey = y;
            bool fin = true;
            while (fin)
            {
                plasex += nx;
                plasey += ny;
                if (boardinfo[plasey, plasex] == turn)
                {
                    fin = false;
                }
                else
                {
                    boardinfo[plasey, plasex] = turn;
                }
            }
        }
        turn *= -1;
        Checkit();

    }
    /// <summary>
    /// ボード情報更新
    /// </summary>
    private void Checkit()
    {
        int Bl = 0, Wh = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int state = boardinfo[i, j];
                GameObject disc = disclist[i, j];
                switch (state)
                {
                    case -1:
                        Wh++;
                        break;
                    case 1:
                        Bl++;
                        break;
                }
                if (!(state == 0) && !disc.activeSelf)
                {
                    disc.SetActive(true);
                }
                disc.GetComponent<Disc>().Reload(state);
            }
        }
        BoardReset();
        Bltext.text = "Black:" + Bl;
        Whtext.text = "White:" + Wh;

    }

    private void BoardReset()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (boardinfo[i, j] == 0)
                {
                    boardcheck[i, j] = CheckAd(i, j);
                }
                else
                {
                    boardcheck[i, j] = false;
                }
                Boardlist[i, j].GetComponent<BoardManager>().ChengeColor(boardcheck[i, j]);
            }
        }
    }
    /// <summary>
    /// 隣が敵と接しているかをチェック
    /// </summary>
    /// <param name="y">チェックするY座標</param>
    /// <param name="x">チェックするX座標</param>
    /// <returns>配置可能かどうか</returns>
    private bool CheckAd(int y, int x)
    {
        bool result = false;
        table[y, x] = new List<int>();
        for (int ny = -1; ny <= 1; ny++)
        {
            if ((ny == -1 && y == 0) || (ny == 1 && y == 7))
            {
                continue;
            }
            for (int nx = -1; nx <= 1; nx++)
            {
                if ((nx == -1 && x == 0) || (nx == 1 && x == 7) || (nx == 0 && ny == 0))
                {
                    continue;
                }
                if (boardinfo[y + ny, x + nx] == (turn * -1))
                {
                    if (CheckLine(ny, nx, y, x))
                    {
                        result = true;
                        table[y, x].Add((nx + 1) + ((ny + 1) * 3));
                    }
                }
            }
        }
        Debug.Log("Turn Discs are" + table[y, x].Count);
        return result;
    }

    private bool CheckLine(int ny, int nx, int y, int x)
    {
        int nowx = x, nowy = y;
        while (true)
        {
            nowx += nx;
            nowy += ny;;
            if (nowx < 0 || nowx > 7 || nowy < 0 || nowy > 7)
            {
                return false;
            }
            if (boardinfo[nowy, nowx] == turn)
            {
                return true;
            }
            if (boardinfo[nowy, nowx] == 0)
            {
                return false;
            }
        }
    }
}
