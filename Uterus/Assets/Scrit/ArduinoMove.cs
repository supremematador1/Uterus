<<<<<<< HEAD
﻿using System.Collections;
using UnityEngine;
using System.IO.Ports;

public class ArduinoMove : MonoBehaviour
{
    public GameObject Cateter;
    public GameObject Catetercito;
    private float lerptime = 0.3f;
    private float currentlerptime = 0;
    private double Registro = 1;
    private Vector3 startPos; //start
    private Vector3 endPos; //end
    private Vector3 startPos2; //start
    private Vector3 endPos2; //end
    SerialPort sp = new SerialPort("COM6", 9600);
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0.19f, 1.83f, -5.56f);
        endPos = new Vector3(0.19f, 1.83f, -5.56f);
        startPos2 = new Vector3(6.576f, 0.958f, 6.942f);
        endPos2 = new Vector3(6.576f, 0.958f, 6.942f);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch
            {

            }
        }
    }

    void MoveObject(int Direction)
    {
        if (Direction == 1 && Registro == 2)
        {
            startPos = Cateter.transform.position = new Vector3(0.19f, 1.01f, -2.56f);
            endPos = Cateter.transform.position = new Vector3(0.19f, 1.83f, -5.56f);
            startPos2 = Catetercito.transform.position = new Vector3(7.35f, 1.37f, 6.44f);
            endPos2 = Catetercito.transform.position = new Vector3(6.576f, 0.958f, 6.942f);
            // For movement transform.Translate(Vector3.left * amountmove, Space.Self);
            //transform.position = new Vector3(0.14f, 1.206f, -4.267f);  //Versión 1.0
            // Para rotation transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Registro = 1;
            currentlerptime = 0;
        }
        if (Direction == 2 && Registro == 1)
        {
            startPos = Cateter.transform.position = new Vector3(0.19f, 1.83f, -5.56f);//First position
            endPos = Cateter.transform.position = new Vector3(0.19f, 1.01f, -2.56f);//Second position
            startPos2 = Catetercito.transform.position = new Vector3(6.576f, 0.958f, 6.942f);//First position
            endPos2 = Catetercito.transform.position = new Vector3(7.35f, 1.37f, 6.44f);//Second position
                                                                                        // For movement transform.Translate(Vector3.up * amountmove, Space.Self);
                                                                                        //transform.position = new Vector3(0.14f, 0.04f, 0.22f); //Versión1.0
            Registro = 2;
            currentlerptime = 0;
        }
        if (Direction == 2 && Registro == 3)
        {
            startPos = Cateter.transform.position = new Vector3(0.19f, -0.13f, 1.74f);//First position
            endPos = Cateter.transform.position = new Vector3(0.19f, 1.01f, -2.56f);//Second position
            startPos2 = Catetercito.transform.position = new Vector3(8.14f, 1.79f, 5.92f);//First position
            endPos2 = Catetercito.transform.position = new Vector3(7.35f, 1.37f, 6.44f);//Second position
                                                                                        // For movement transform.Translate(Vector3.up * amountmove, Space.Self);
                                                                                        //transform.position = new Vector3(0.14f, 0.04f, 0.22f); //Versión1.0
            Registro = 2;
            currentlerptime = 0;
        }
        if (Direction == 3 & Registro == 2)
        {
            startPos = Cateter.transform.position = new Vector3(0.19f, 1.01f, -2.56f);//First position
            endPos = Cateter.transform.position = new Vector3(0.19f, -0.13f, 1.74f); //Second position
            startPos2 = Catetercito.transform.position = new Vector3(7.35f, 1.37f, 6.44f);//First position
            endPos2 = Catetercito.transform.position = new Vector3(8.14f, 1.79f, 5.92f); //Second position
                                                                                         // For movement transform.Translate(Vector3.right * amountmove, Space.Self);
                                                                                         //transform.position = new Vector3(0.14f, -0.85f, 3.67f); //Versión1.0
            Registro = 3;
            currentlerptime = 0;
        }
        currentlerptime += Time.deltaTime;
        if (currentlerptime >= lerptime)
        {
            currentlerptime = lerptime;
        }
        float Perc = currentlerptime / lerptime;
        Cateter.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        Catetercito.transform.position = Vector3.Lerp(startPos2, endPos2, Perc);
    }
}
=======
﻿using System.Collections;
using UnityEngine;
using System.IO.Ports;

public class ArduinoMove : MonoBehaviour
{
    public GameObject Cateter;
    private float lerptime = 0.3f;
    private float currentlerptime = 0;
    private double Registro = 1;
    private Vector3 startPos; //start
    private Vector3 endPos; //end
    SerialPort sp = new SerialPort("COM9", 9600);
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0.14f, 1.206f, -4.26f);
        endPos = new Vector3(0.14f, 1.206f, -4.26f);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch
            {

            }
        }
    }

    void MoveObject(int Direction)
    {
        if (Direction == 1 && Registro == 2)
        {
            startPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);
            endPos = Cateter.transform.position = new Vector3(0.14f, 1.206f, -4.26f);
            // For movement transform.Translate(Vector3.left * amountmove, Space.Self);
            //transform.position = new Vector3(0.14f, 1.206f, -4.267f);  //Versión 1.0
            // Para rotation transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Registro = 1;
            currentlerptime = 0;
        }
        if (Direction == 2 && Registro == 1)
        {
            startPos = Cateter.transform.position = new Vector3(0.14f, 1.206f, -4.26f);//First position
            endPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);//Second position
                                                                                   // For movement transform.Translate(Vector3.up * amountmove, Space.Self);
                                                                                   //transform.position = new Vector3(0.14f, 0.04f, 0.22f); //Versión1.0
            Registro = 2;
            currentlerptime = 0;
        }
        if (Direction == 2 && Registro == 3)
        {
            startPos = Cateter.transform.position = new Vector3(0.14f, -0.85f, 3.67f);//First position
            endPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);//Second position
                                                                                   // For movement transform.Translate(Vector3.up * amountmove, Space.Self);
                                                                                   //transform.position = new Vector3(0.14f, 0.04f, 0.22f); //Versión1.0
            Registro = 2;
            currentlerptime = 0;
        }
        if (Direction == 3 & Registro == 2)
        {
            startPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);//First position
            endPos = Cateter.transform.position = new Vector3(0.14f, -0.85f, 3.67f); //Second position
                                                                                     // For movement transform.Translate(Vector3.right * amountmove, Space.Self);
                                                                                     //transform.position = new Vector3(0.14f, -0.85f, 3.67f); //Versión1.0
            Registro = 3;
            currentlerptime = 0;
        }
        currentlerptime += Time.deltaTime;
        if (currentlerptime >= lerptime)
        {
            currentlerptime = lerptime;
        }
        float Perc = currentlerptime / lerptime;
        Cateter.transform.position = Vector3.Lerp(startPos, endPos, Perc);
    }
}
>>>>>>> 657863836e17611d07d84557674247aab616d309
