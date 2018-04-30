using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour {


    //public Rigidbody ball;

    public float h = 25;
    public float gravity  = -18;

    private int debugPath =0;

    // Use this for initialization

    public void Launch(RaycastHit hit, GameObject grenade)
    {
        Debug.Log("hi there");
        Rigidbody ball = grenade.GetComponent<Rigidbody>();
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        ball.velocity = CalculateLaunchVelocity(hit , ball).initialVelocity;
    }

    public LaunchData CalculateLaunchVelocity(RaycastHit hit , Rigidbody ball)
    {

       


        float displacement = hit.point.y - ball.position.y;
        Vector3 displacementxz = new Vector3(hit.point.x - ball.position.x, 0, hit.point.z - ball.position.z);
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacement - h) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementxz / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacement - h) / gravity));

        return new LaunchData (velocityXZ + velocityY * -Mathf.Sign(gravity),time);
    }

    //void drowPath()
    //{
       // LaunchData launchData = CalculateLaunchVelocity();
       // Vector3 previousDrawPoint = ball.position;

       // int resolution = 30;
        //for(int i =1; i<= resolution; i++)
       // {
         //   float simulationTime = i / (float)resolution * launchData.timeTarget;
          //  Vector3 displacment = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
          //  Vector3 drowpoint = ball.position + displacment;
           // Debug.DrawLine(previousDrawPoint, drowpoint, Color.blue);
           // previousDrawPoint = drowpoint;
       // }
  //  }

     public struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeTarget;

        public LaunchData(Vector3 initialVelocity , float timeTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeTarget = timeTarget;
        }
    }


}
