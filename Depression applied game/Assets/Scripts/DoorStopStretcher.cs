using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStopStretcher : MonoBehaviour
{
    [SerializeField]
    private GameObject _DoorStep, _Player;

    private float _Distance;

    private float _Percentage;

    private float originalyScale;

    private void Start()
    {
        originalyScale = _DoorStep.transform.localScale.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Distance = Vector3.Distance(_DoorStep.transform.position, _Player.transform.position);
            _Percentage = 100;
            //Debug.Log("Entered");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            float scaleMultiplier = 101 - _Percentage;
            _DoorStep.transform.localScale = new Vector3(_DoorStep.transform.localScale.x, originalyScale * scaleMultiplier, _DoorStep.transform.localScale.z);
            _Percentage = (Vector3.Distance(_DoorStep.transform.position, _Player.transform.position) / _Distance) * 100;
            //Debug.Log(_Percentage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _Percentage = 100;
    }
}
