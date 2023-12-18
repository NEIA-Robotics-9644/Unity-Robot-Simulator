using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private SwerveModule frontLeft;
    [SerializeField] private SwerveModule frontRight;
    [SerializeField] private SwerveModule backLeft;
    [SerializeField] private SwerveModule backRight;

    private float _oldTime = 0.0f;
    
    void Update()
    {
        if (Time.time > _oldTime + 0.1f)
        {
            _oldTime = Time.time;
            
            RobotDataManager dataManager = RobotDataManager.Instance;
            frontLeft.SetVelocity(dataManager.GetRobotDataDouble("Swerve Front Left Drive Velocity"));
            frontLeft.SetAngle(dataManager.GetRobotDataDouble("Swerve Front Left Angle"));
        
            frontRight.SetVelocity(dataManager.GetRobotDataDouble("Swerve Front Right Drive Velocity"));
            frontRight.SetAngle(dataManager.GetRobotDataDouble("Swerve Front Right Angle"));
        
            backLeft.SetVelocity(dataManager.GetRobotDataDouble("Swerve Back Left Drive Velocity"));
            backLeft.SetAngle(dataManager.GetRobotDataDouble("Swerve Back Left Angle"));
        
            backRight.SetVelocity(dataManager.GetRobotDataDouble("Swerve Back Right Drive Velocity"));
            backRight.SetAngle(dataManager.GetRobotDataDouble("Swerve Back Right Angle"));
            
            dataManager.SetRobotData("Gyro Angle", transform.localRotation.eulerAngles.y);

            

        }
        
    }
  
}
