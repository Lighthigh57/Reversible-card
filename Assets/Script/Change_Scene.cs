using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    private AudioSource player;

    public AudioClip clip;
    // Update ���\�b�h�����߂ČĂяo����钼�O�� Start ���Ăяo����܂�
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
