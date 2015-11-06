using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour
{
    public Transform squid;
    bool isDeathTimerRunning = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeathTimerRunning && squid.position.y - transform.position.y > 20)
            StartCoroutine("StartDeathTimer");
    }

    IEnumerable StartDeathTimer()
    {
        isDeathTimerRunning = true;
        yield return new WaitForSeconds(5);
        isDeathTimerRunning = false;
        SimplePool.Despawn(gameObject);
    }
}
