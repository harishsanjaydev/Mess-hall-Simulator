using UnityEngine;
public class FanSpin : MonoBehaviour
{
    public float spinSpeed = 200f;
    
    void Update()
    {
        transform.Rotate(0, 0, -spinSpeed * Time.deltaTime);
    }
}