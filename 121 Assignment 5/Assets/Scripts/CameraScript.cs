using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Text QText;

    private Vector3 offset;
    private Vector3 rotation;
    private bool thirdPerson = true;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QText.enabled = false;
            if (thirdPerson)
            {
                transform.eulerAngles = player.transform.eulerAngles;
                transform.position = player.transform.position;
                thirdPerson = false;
            }
            else
            {
                rotation = player.transform.eulerAngles;
                rotation.x = 25;
                transform.eulerAngles = rotation;
                transform.position += transform.forward * -10;
                thirdPerson = true;
            }
        }
    }
}
