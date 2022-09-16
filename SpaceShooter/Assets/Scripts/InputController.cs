using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerData data;

    private void Awake()
    {
        data = GetComponent<PlayerData>();
    }


    void Update()
    {
        data.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), data.Direction.z);
    }


}
