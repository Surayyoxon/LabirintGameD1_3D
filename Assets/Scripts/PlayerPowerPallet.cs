using UnityEngine;
using System.Collections;

public class PlayerPowerPallet : MonoBehaviour
{
    [Header("Power Settings")]
    [SerializeField] private float powerDuration = 15f;

    private bool isPoweredUp = false;

    private float remainingPowerTime;

    private Coroutine powerCoroutine;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PowerPallet"))
            return;

        ActivatePower();

        Destroy(other.gameObject);
    }


    private void ActivatePower()
    {
        if (powerCoroutine != null)
        {
            StopCoroutine(powerCoroutine);
        }

        powerCoroutine =
            StartCoroutine(PowerMode());
    }


    private IEnumerator PowerMode()
    {
        isPoweredUp = true;

        remainingPowerTime =
            powerDuration;

        Debug.Log("POWER MODE ON!");

        while (remainingPowerTime > 0f)
        {
            remainingPowerTime -=
                Time.deltaTime;

            yield return null;
        }

        remainingPowerTime = 0f;

        isPoweredUp = false;

        Debug.Log("POWER MODE OFF!");

        powerCoroutine = null;
    }


    public bool IsPoweredUp()
    {
        return isPoweredUp;
    }


    public float GetRemainingPowerTime()
    {
        return remainingPowerTime;
    }


    public float GetPowerDuration()
    {
        return powerDuration;
    }
}