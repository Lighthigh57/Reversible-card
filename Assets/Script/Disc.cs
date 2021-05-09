using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    int state = 1;
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    public void reload(int remoteState)
    {
        if (state == remoteState)
        {
            return;
        }

        rig.AddForce(0, 15.0f, 0);
        state = remoteState;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.eulerAngles.x - (90 + 90 * state)) < 5)
        {
            rig.AddTorque(5.0f, 0, 0);
        }

    }
}