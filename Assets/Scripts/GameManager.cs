using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float respownTime = 1.0f;
    public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespwnTimed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RespwnTimed()
    {
        while (true)
        {
            yield return new WaitForSeconds(respownTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
