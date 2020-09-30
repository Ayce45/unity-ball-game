using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [Tooltip("Target element")]
    public GameObject target;
    [Tooltip("deadZone in unite")]
    public int deadZone;
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.transform.position.x - target.transform.position.x > deadZone)
        {
            this.transform.position = new Vector3(target.transform.position.x + deadZone, this.transform.position.y, this.transform.position.z);
        }
        else if (this.transform.position.x - target.transform.position.x < -deadZone)
        {
            this.transform.position = new Vector3(target.transform.position.x - deadZone, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.y - target.transform.position.y > deadZone)
        {
            this.transform.position = new Vector3(this.transform.position.x, target.transform.position.y + deadZone, this.transform.position.z);
        }
        else if (this.transform.position.y - target.transform.position.y < -deadZone)
        {
            this.transform.position = new Vector3(this.transform.position.x, target.transform.position.y - deadZone, this.transform.position.z);

        }
    }
}
