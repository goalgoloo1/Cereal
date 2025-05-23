using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public int num;
    public bool isRepeat;
    public float isRnd=0;
    public UnityEngine.Events.UnityEvent OnTime;

    int  num_count;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Act());    }

    IEnumerator Act()
    {
        if (isRepeat)
        {
            for (; ; )
            {

                yield return new WaitForSeconds(GetTime());
                
                num_count++;
                if (num_count > num) break;
                OnTime.Invoke();
            }
        }
        else
        { 
            yield return new WaitForSeconds(GetTime());
            OnTime.Invoke();
        }
    }
    float GetTime()
    {
        float f = time;

        if (isRnd != 0) 
            f = Random.RandomRange(isRnd, time);

        return f;
    }
    public void SeparateParent() { transform.parent = null; }
    public void Destme() { Destroy(gameObject); }
    public void Inst(GameObject go) { Instantiate(go, transform.position, transform.rotation); }
}


