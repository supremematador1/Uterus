using System.IO.Ports;
using UnityEngine;
public class ArduinoMove : MonoBehaviour
{
    //private float yaw = 0.0f;
    //private float pitch = 0.0f;
    //public float HSpeed = 1.0f;
    //public float VSpeed = 1.0f;
    public GameObject Cateter;
    private double Registro = 1;
    private Vector3 startPos; //start
    private Vector3 endPos; //end
    private float lerptime = 0.5f; //Time it will take to move
    private float currentlerptime = 0; //This will update the lerp time
    public static SerialPort sp = new SerialPort("COM4", 9600);
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

        //////                 POR SI SE QUIERE CONTROLAR LA ORIENTACIÓN DEL OBJECTO CON EL MOUSE                ///////
        //yaw += HSpeed * Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        //pitch -= VSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime * 180;
        //yaw = Mathf.Clamp(yaw, -90f, 90f);//the rotation range
        //pitch = Mathf.Clamp(pitch, -60f, 90f); //the rotation range
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       

        void MoveObject(int Direction)
        {
            if (Direction == 1 && Registro == 1)
            {
                startPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);
                endPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);
                // For movement transform.Translate(Vector3.left * amountmove, Space.Self);
                //transform.position = new Vector3(0.14f, 1.206f, -4.267f);  //Versión 1.0
                // Para rotation transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Registro = 1;
                currentlerptime = 0;
            }
            if (Direction == 1 && Registro == 2)
            {
                startPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);
                endPos = Cateter.transform.position = new Vector3(0.14f, 1.206f, -4.26f);
                // For movement transform.Translate(Vector3.left * amountmove, Space.Self);
                //transform.position = new Vector3(0.14f, 1.206f, -4.267f);  //Versión 1.0
                // Para rotation transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Registro = 0;
                currentlerptime = 0;
            }
            if (Direction == 1 && Registro == 2)
            {
                startPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);
                endPos = Cateter.transform.position = new Vector3(0.14f, 1.206f, -4.26f);
                // For movement transform.Translate(Vector3.left * amountmove, Space.Self);
                //transform.position = new Vector3(0.14f, 1.206f, -4.267f);  //Versión 1.0
                // Para rotation transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Registro = 0;
                currentlerptime = 0;
            }
            if (Direction == 2 && Registro == 1)
            {
                startPos = Cateter.transform.position = new Vector3(0.14f, 1.206f, -4.26f);//First position
                endPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);//Second position
                                                                                       // For movement transform.Translate(Vector3.up * amountmove, Space.Self);
                                                                                       //transform.position = new Vector3(0.14f, 0.04f, 0.22f); //Versión1.0
                Registro = 1;
                currentlerptime = 0;
            }
            if (Direction == 2 && Registro == 3)
            {
                startPos = Cateter.transform.position = new Vector3(0.14f, -0.85f, 3.67f);//First position
                endPos = Cateter.transform.position = new Vector3(0.14f, 0.04f, 0.22f);//Second position
                                                                                       // For movement transform.Translate(Vector3.up * amountmove, Space.Self);
                                                                                       //transform.position = new Vector3(0.14f, 0.04f, 0.22f); //Versión1.0
                Registro = 1;
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
            // SI QUISIERAS AGREGAR UN CUARTO SENSOR (4)
            //if (Direction ==4)
            //{
            //   transform.position = new Vector3(0f, -7f, 21f);
            //}
            currentlerptime += Time.deltaTime;
            if (currentlerptime >= lerptime)
            {
                currentlerptime = lerptime;
            }
            float Perc = currentlerptime / lerptime;
            Cateter.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }
    }
}