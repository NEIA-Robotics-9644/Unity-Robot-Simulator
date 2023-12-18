using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Scripting.Python;
using UnityEngine;


public class RobotDataManager : MonoBehaviour
{
    // Singleton
    public static RobotDataManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("RobotDataManager already exists!");
        }
    }

    [SerializeField] private string simulatorIP = "10.0.0.25";
    
    public string GetSimulatorIP()
    {
        return simulatorIP;
    }

    private Dictionary<string, object> transmitData = new Dictionary<string, object>();
    private Dictionary<string, object> receiveData = new Dictionary<string, object>();

    public void SetSimulatorData(string key, object value)
    {
        receiveData[key] = value;
    }
    
    public void SetRobotData(string key, object value)
    {
        transmitData[key] = value;
    }

    public string GetRobotDataString(string key)
    {
        return receiveData[key].ToString();
    }

    public double GetRobotDataDouble(string key)
    {
        return Double.Parse(receiveData[key].ToString());
    }

    public Dictionary<String, object> GetTransmitData()
    {
        return transmitData;
    }
    
    private float _oldTime = 0.0f;
    
    void Update()
    {

        if (Time.time > _oldTime + 0.1f)
        {
            _oldTime = Time.time;

            string scriptPath = Path.Combine(Application.dataPath, "pull_network_tables_data.py");
            PythonRunner.RunFile(scriptPath);

            
        }
    }
    
    
    
    
}


