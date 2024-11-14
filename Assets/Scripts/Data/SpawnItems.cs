using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class SpawnItems : MonoBehaviour
{
    public float MinDuration;
    public float MaxDuration;
    private float[] durationTime = new float[2];
    private float[] checkTime = new float[2];

    private void Update()
    {
        for (int i = 0; i < durationTime.Length; i++)
        {
            checkTime[i] += Time.deltaTime;
            if (checkTime[i] > durationTime[i])
            {
                SpawnItem(i);
                durationTime[i] = Random.Range(MinDuration, MaxDuration);
                checkTime[i] = 0;
            }
        }
    }

    private void SpawnItem(int i)
    {
        GameObject itemClone = ObjectPool.Instance.SpawnFromPool($"Item{i}");
        if (itemClone != null)
        {
            if (i % 2 == 0)
            {
                itemClone.transform.position = new Vector3(Random.Range(-20f,20f), 0f, Random.Range(0f,7f));
            }
            else
            {
                itemClone.transform.position = new Vector3(Random.Range(-20f, 20f), 0.25f, Random.Range(0f, 7f));
            }

        }

    }

}

