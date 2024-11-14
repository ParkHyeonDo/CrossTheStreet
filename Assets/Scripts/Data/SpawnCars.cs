using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class SpawnCars : MonoBehaviour
{
    public float MinDuration;
    public float MaxDuration;
    private float[] durationTime= new float[4];
    private float[] checkTime= new float[4];
    private float interval = 2f;
    


    private void Update()
    {
        for (int i = 0; i < durationTime.Length; i++)
        {
            checkTime[i] += Time.deltaTime;
            if (checkTime[i] > durationTime[i])
            {
                SpawnCar(i);
                durationTime[i] = Random.Range(MinDuration, MaxDuration);
                checkTime[i] = 0;
            }
        }
    }

    private void SpawnCar(int i)
    {
        GameObject carClone = ObjectPool.Instance.SpawnFromPool($"Car{i}");
        if (carClone != null) 
        {
            if (i % 2 == 0)
            {
                carClone.transform.position = new Vector3(20f, 0.35f, interval *(i+1));
            }
            else 
            {
                carClone.transform.position = new Vector3(-20f, 0.35f, interval * (i + 1));
                //carClone.transform.rotation = Quaternion.Euler(0f,0f,180f);
            }
            
        }

    }
}

