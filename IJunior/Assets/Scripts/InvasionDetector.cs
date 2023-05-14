using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvasionDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _invasion;
    [SerializeField] private AudioSource aus;
    private bool _isInvasion;
    
    public void ChangeVolume()
    {
        float volumeStep = 0.01f;
        float maxVolume = 1f;
        float minVolume = 0;

        if (_isInvasion)
        {
            aus.volume = Mathf.MoveTowards(aus.volume, maxVolume, volumeStep);
        }
        else
        {
            aus.volume = Mathf.MoveTowards(aus.volume, minVolume, volumeStep);
        }


    }

    private void Update()
    {
        ChangeVolume();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _isInvasion = true;

            aus.volume = 0;
            aus.Play();

            _invasion?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _isInvasion = false;
        }
    }

}
