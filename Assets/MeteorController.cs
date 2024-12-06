using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private float fallSpeed = 0.01f;
    private float rotationSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if(transform.position.y < - 6f || transform.position.x < -10f){
          ResetPosition();
        }
        else {
            MoveMeteor();
            RotateMeteor();
        }
    }
    private void MoveMeteor()
    {
        transform.Translate(-fallSpeed, -fallSpeed, 0, Space.World);
    }

    private void ResetPosition(){
        float randomx = Random.Range(-7f, 10f);
        transform.position = new Vector3(randomx, 6f);
    }

     private void RotateMeteor(){
        transform.Rotate(0, 0, rotationSpeed, Space.Self);
    }

   
}
