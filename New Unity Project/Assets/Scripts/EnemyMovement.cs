using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public float percentage;
    public Transform trans;
    public float waitTime;
    public float moveSpeed;

    void Start()
    {
        trans = GetComponent<Transform>();
        StartCoroutine(EnemyMove());
    }

    public IEnumerator EnemyMove()
    {
        percentage = 0;
        Debug.Log("Moving towards B");
        while (percentage < 1)
        {
            percentage += moveSpeed;
            if (percentage > 1)
            {
                percentage = 1;
            }
            float position = Mathf.Lerp(posA.position.x, posB.position.x, percentage);
            trans.position = new Vector3(position, trans.position.y, trans.position.z);
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            trans.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        }
        yield return new WaitForSeconds(waitTime);
        trans.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Debug.Log("Moving towards A");
        percentage = 0;
        while (percentage < 1)
        {
            percentage += moveSpeed;
            if (percentage > 1)
            {
                percentage = 1;
            }
            float position = Mathf.Lerp(posB.position.x, posA.position.x, percentage);
            trans.position = new Vector3(position, trans.position.y, trans.position.z);
            yield return new WaitForSecondsRealtime(Time.deltaTime);
        }
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(EnemyMove());
    }
}


