using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Like update but runs after all items have been processed in update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
