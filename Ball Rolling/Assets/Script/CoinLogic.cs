using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinLogic : MonoBehaviour
{

    private float speed = 1.5f;
    
    
    void Update()
    {
        //format: thisObjectTransForm.RotateMethod(vector3 (struct value) * float value * system.Time.deltaTime)
        transform.Rotate (new UnityEngine.Vector3 (15,30,45) * speed * Time.deltaTime);
        
    }
}
