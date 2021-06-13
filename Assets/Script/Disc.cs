using UnityEngine;

public class Disc : MonoBehaviour
{
    public void Reload(int State)
    {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Color",State==-1);
    }
}