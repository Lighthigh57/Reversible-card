using UnityEngine;

public class Disc : MonoBehaviour
{
    private int state = 1;

    private void Start()
    {

    }

    public void reload(int remoteState)
    {
        if (state == remoteState)
        {
            return;
        }
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Color", !animator.GetBool("Color"));
        state = remoteState;
    }

    private void Update()
    {


    }
}