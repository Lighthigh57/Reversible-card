using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    private AudioSource player;

    public AudioClip clip;
    // Update メソッドが初めて呼び出される直前に Start が呼び出されます
    private void Start()
    {
        player = GetComponent<AudioSource>();
    }
    public void On_Click()
    {
        player.PlayOneShot(clip);
        SceneManager.LoadScene("Game");
    }
}
