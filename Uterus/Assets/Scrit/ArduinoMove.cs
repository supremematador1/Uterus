using System.Collections;
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