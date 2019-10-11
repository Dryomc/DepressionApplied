using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject _Doorstep;

    private float _StartPosition;
    private void Start()
    {
        _StartPosition = transform.position.y;
    }

    void Update()
    {
        float yPosition = _StartPosition + (_Doorstep.transform.localScale.y / 2);

        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
