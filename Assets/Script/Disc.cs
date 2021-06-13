using UnityEngine;

public class Disc : MonoBehaviour
{
    private int state = 1;

    public void Reload(int remoteState)
    {
        if (state != remoteState)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Color", !animator.GetBool("Color"));
            state = remoteState;
        }
    }
}