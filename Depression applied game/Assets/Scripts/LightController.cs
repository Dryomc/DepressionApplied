using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private Light _HallwayLight, _DoorLight;

    [SerializeField]
    private GameObject _Player, _DoorStep;

    private float _Distance;

    private float _Percentage;

    private float _OriginalBrightness;

    private void Start()
    {
        _OriginalBrightness = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Distance = Vector3.Distance(_DoorStep.transform.position, _Player.transform.position);
            _Percentage = 1;
            //Debug.Log("Entered");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //float scaleMultiplier = 101 - _Percentage;
            //_DoorStep.transform.localScale = new Vector3(_DoorStep.transform.localScale.x, originalyScale * scaleMultiplier, _DoorStep.transform.localScale.z);
            float lightScale = 1 * _Percentage;
            float doorLightScale = 2 - lightScale;
            _HallwayLight.intensity = lightScale;
            _DoorLight.intensity = doorLightScale; 
            _Percentage = (Vector3.Distance(_DoorStep.transform.position, _Player.transform.position) / _Distance);
            //Debug.Log(_Percentage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _Percentage = 1;
    }
}
