<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class IMUDOME : MonoBehaviour
{
    SerialPort stream;

    public GameObject target; // is the gameobject to

    float curr_angle_roll = 0;
    float curr_angle_pitch = 0;
    float curr_angle_yaw = 0;


    // Increase the speed/influence rotation
    public float factor = 1;

    public bool enableRotation;
    public bool enableTranslation;

    // SELECT YOUR COM PORT AND BAUDRATE SELECT THE OUTGOING BLUETOOTH COM PORT
    string port = "COM4";
    int baudrate = 9600;
    int readTimeout = 5000;

    void Start()
    {
        // open port. Be shure in unity edit > project settings > player is NET2.0 and not NET2.0Subset
        stream = new SerialPort("\\\\.\\" + port, baudrate);
        stream.DtrEnable = true;
        try
        {
            stream.ReadTimeout = readTimeout;
        }
        catch (System.IO.IOException ioe)
        {
            Debug.Log("IOException: " + ioe.Message);
        }

        stream.Open();
    }

    void Update()
    {
        string dataString = "null received";

        if (stream.IsOpen)
        {
            try
            {
                dataString = stream.ReadLine();
                Debug.Log("RCV_ : " + dataString);
            }
            catch (System.IO.IOException ioe)
            {
                Debug.Log("IOException: " + ioe.Message);
            }

        }
        else
            dataString = "NOT OPEN";
        Debug.Log("RCV_ : " + dataString);

        if (!dataString.Equals("NOT OPEN"))
        {
            // recived string is  like  "accx;accy;accz;gyrox;gyroy;gyroz"
            char splitChar = ';';
            string[] dataRaw = dataString.Split(splitChar);

            // normalized accelerometer values
            float roll = float.Parse(dataRaw[0]);
            float pitch = float.Parse(dataRaw[1]);
            float yaw = float.Parse(dataRaw[2]);
            print(curr_angle_roll);
            print(curr_angle_pitch);
            print(curr_angle_yaw);

            curr_angle_roll = roll;
            curr_angle_pitch = pitch;
            curr_angle_yaw = yaw;

            //Salida a objeto
            if (enableRotation) target.transform.rotation = Quaternion.Euler(curr_angle_roll * factor, curr_angle_yaw * factor, curr_angle_pitch * factor);
        }
    }

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class IMUDOME : MonoBehaviour
{
    SerialPort stream;

    public GameObject target; // is the gameobject to

    float curr_angle_roll = 0;
    float curr_angle_pitch = 0;
    float curr_angle_yaw = 0;


    // Increase the speed/influence rotation
    public float factor = 7;

    public bool enableRotation;
    public bool enableTranslation;

    // SELECT YOUR COM PORT AND BAUDRATE SELECT THE OUTGOING BLUETOOTH COM PORT
    string port = "COM4";
    int baudrate = 9600;
    int readTimeout = 100;

    void Start()
    {
        // open port. Be shure in unity edit > project settings > player is NET2.0 and not NET2.0Subset
        stream = new SerialPort("\\\\.\\" + port, baudrate);

        try
        {
            stream.ReadTimeout = readTimeout;
        }
        catch (System.IO.IOException ioe)
        {
            Debug.Log("IOException: " + ioe.Message);
        }

        stream.Open();
    }

    void Update()
    {
        string dataString = "null received";

        if (stream.IsOpen)
        {
            try
            {
                dataString = stream.ReadLine();
                Debug.Log("RCV_ : " + dataString);
            }
            catch (System.IO.IOException ioe)
            {
                Debug.Log("IOException: " + ioe.Message);
            }

        }
        else
            dataString = "NOT OPEN";
        Debug.Log("RCV_ : " + dataString);

        if (!dataString.Equals("NOT OPEN"))
        {
            // recived string is  like  "accx;accy;accz;gyrox;gyroy;gyroz"
            char splitChar = ';';
            string[] dataRaw = dataString.Split(splitChar);
            
            // normalized accelerometer values
            float roll = float.Parse(dataRaw[0]);
            float pitch = float.Parse(dataRaw[1]);
            float yaw = float.Parse(dataRaw[2]);
            print(curr_angle_roll);
            print(curr_angle_pitch);
            print(curr_angle_yaw);

            curr_angle_roll = roll;
            curr_angle_pitch = pitch;
            curr_angle_yaw = yaw;

            //Salida a objeto
            if (enableRotation) target.transform.rotation = Quaternion.Euler(curr_angle_pitch * factor, curr_angle_yaw * factor, curr_angle_roll * factor);
        }
    }

}
>>>>>>> 657863836e17611d07d84557674247aab616d309
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class IMUDOME : MonoBehaviour
{
    SerialPort stream;

    public GameObject target; // is the gameobject to

    float curr_angle_roll = 0;
    float curr_angle_pitch = 0;
    float curr_angle_yaw = 0;


    // Increase the speed/influence rotation
    public float factor = 7;

    public bool enableRotation;
    public bool enableTranslation;

    // SELECT YOUR COM PORT AND BAUDRATE SELECT THE OUTGOING BLUETOOTH COM PORT
    string port = "COM4";
    int baudrate = 9600;
    int readTimeout = 100;

    void Start()
    {
        // open port. Be shure in unity edit > project settings > player is NET2.0 and not NET2.0Subset
        stream = new SerialPort("\\\\.\\" + port, baudrate);

        try
        {
            stream.ReadTimeout = readTimeout;
        }
        catch (System.IO.IOException ioe)
        {
            Debug.Log("IOException: " + ioe.Message);
        }

        stream.Open();
    }

    void Update()
    {
        string dataString = "null received";

        if (stream.IsOpen)
        {
            try
            {
                dataString = stream.ReadLine();
                Debug.Log("RCV_ : " + dataString);
            }
            catch (System.IO.IOException ioe)
            {
                Debug.Log("IOException: " + ioe.Message);
            }

        }
        else
            dataString = "NOT OPEN";
        Debug.Log("RCV_ : " + dataString);

        if (!dataString.Equals("NOT OPEN"))
        {
            // recived string is  like  "accx;accy;accz;gyrox;gyroy;gyroz"
            char splitChar = ';';
            string[] dataRaw = dataString.Split(splitChar);
            
            // normalized accelerometer values
            float roll = float.Parse(dataRaw[0]);
            float pitch = float.Parse(dataRaw[1]);
            float yaw = float.Parse(dataRaw[2]);
            print(curr_angle_roll);
            print(curr_angle_pitch);
            print(curr_angle_yaw);

            curr_angle_roll = roll;
            curr_angle_pitch = pitch;
            curr_angle_yaw = yaw;

            //Salida a objeto
            if (enableRotation) target.transform.rotation = Quaternion.Euler(curr_angle_pitch * factor, curr_angle_yaw * factor, curr_angle_roll * factor);
        }
    }

}
>>>>>>> 657863836e17611d07d84557674247aab616d309
