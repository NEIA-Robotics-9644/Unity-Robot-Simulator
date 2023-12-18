import UnityEngine
import sys
import networktables
import ntcore
import wpilib
import time
import json

UnityEngine.Debug.Log("Python File Running...")

# Get the Unity Robot Data Manager singleton instance
robot_data_manager_script = (UnityEngine.GameObject.FindGameObjectWithTag("Robot Data Manager")
                             .GetComponent("RobotDataManager"))

# Read data from the networktables

ip_address = robot_data_manager_script.GetSimulatorIP()

networktables.NetworkTables.initialize(ip_address)
receiveEntry = networktables.NetworkTables.getTable("Simulation").getEntry("RobotJSONData")
transmitEntry = networktables.NetworkTables.getTable("Simulation").getEntry("SimulatorJSONData")

# Receive and JSON decode the data
receive_JSON_data = json.loads(receiveEntry.getString("{}"))


for key in receive_JSON_data:
    robot_data_manager_script.SetSimulatorData(key, receive_JSON_data[key])

# Transmit data to the networktables
transmit_JSON_data = json.dumps(dict(robot_data_manager_script.GetTransmitData()))
transmitEntry.setString(transmit_JSON_data)
