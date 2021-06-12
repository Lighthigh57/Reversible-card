using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Material[] color = new Material[3];
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
                    }
    public void PointerEnter()
                    {
        GetComponent<Renderer>().material = color[2];
                        }
    public void PointerExit()
                        {
        GetComponent<Renderer>().material = color[0];
                        }
    public void PointerClick()
            {
        int x = (int)(GetComponent<Transform>().position.x+3.5f);
        int y = (int)Mathf.Abs(GetComponent<Transform>().position.z-3.5f);
        manager.GetComponent<GameManager>().TurnDisc(y,x);
    }

}
