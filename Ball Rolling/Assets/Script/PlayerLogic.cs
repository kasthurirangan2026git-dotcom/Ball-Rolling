// nameSpace area
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

// format accessModifier class  ClassName : Inheritance
public class PlayerLogic : MonoBehaviour
{
    // Creating a object instance of Rigidbody class
    // rigidbody class of many costom physics method to use
    // format: acessModifier ClassName object; (object is instance of class)
    private Rigidbody rb;

    //storing TextMestUGUI var for showcasing score + fps + time etc...  
    public TextMeshProUGUI scorePoint;
    public TextMeshProUGUI FPSText;

    // storing textMeshpro var for showing you win you loss message
    public GameObject winText;

    public GameObject lossText;

    // Creating float variable for convert our vector2 value into vector3 because object.AddforceMethod(Vector3); only use Vector3 
    private float movementX;
    private float movementZ;


    // add variable for boost movement speed
    private float movementSpeed = 5f;

    // add variable for store Score Count
    public int scoreCount = 0;

    public GameObject joyStick;

    //format: acessModifer ClassName Object;
    public AudioSource audioSource;

    public AudioClip deadSound;

    private MeshRenderer mesh;



    
    


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        // (inniziating/connecting) this.GameObject.Component.Rigidbody to RigidBody.rb = ClassName.Object in first frame of the game 
        rb =  GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();

        Application.targetFrameRate = 60;

        // inniziating ScoreCount value 
        ScoreSystem();

        // disable wintext screen at start of the game

        winText.gameObject.SetActive(false);

        lossText.gameObject.SetActive(false);
        
    }

    // this method not return any value
    // method using InputValue Class as argument parameter
    // then use to plass input value to other struct variable
    // InputValue is class and inputValue is instance of class we call as object
    // Void is used for prevent Method returning any value such as int float bool etc...
    //format: acessModifier void Method(className object);
    public void OnMove(InputValue inputValue)
    { 
        // format: struct variableName = object.method<T>();
        Vector2 MovementVector =  inputValue.Get<Vector2>();

        // Converting (struct)vector2 variable into float variable value by specifying struct_instance.fields example: struct_instance.y 
        movementX = MovementVector.x;
        movementZ = MovementVector.y;
    }


    void Update()
    {
        
        // rigidbody only allow Vactor3 value so we converting by 
        // struct variableName = ((new) iniziate to allocate memory in ram for store ) datatype struct(x,y,z);   
        Vector3 threeAxisVAlue = new Vector3(movementX,0f,movementZ);
        
        // adding force to the GameObject by altering its rigidbody values
        // format: object.method(argument parameter)
        rb.AddForce(threeAxisVAlue * movementSpeed, ForceMode.Acceleration);
        

        FPSText.text = "FPS: " + Application.targetFrameRate;
        
    }

    // OnTriggeerEnter is Method from UnityEngine NameSpace
    // format: void methodName(className Object) 
    void OnTriggerEnter(Collider other)
    {
        // if this GameObject Colider touch other GameObject Collider that set as trigger in collider componant
        // Compare its tag by using CompareTag method(name of the tag) and return bool value
        //format: if(object.thisgameObject.MethodName("String")){}
        
        if (other.gameObject.CompareTag("Coin"))

        {   
            // if bool value true 
            //Every GameObject have 2 state (active/disable) you can toggle this in higerarky window by toggling this we can remove GameObject from game Scene
            //SetActive method used for set gameobject (active/disable) by using argument parameter bool
            // format: object.this.gameObject.MethodName(bool);
            other.gameObject.SetActive(false);

            // adding value 1 in every other.gameObject.CompareTag("string") == true;
            // scoreCount++ mean scoreCount = Previous scoreCount Value + (1)); 
            scoreCount++;

            //Checking current scoreCount Value by using Debug.LogMethod(variableName);
            //Debug.Log(scoreCount);
            ScoreSystem();


            if (scoreCount == 16)
            {
                
                winText.gameObject.SetActive(true);
                scorePoint.text = "";
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));

                StartCoroutine(Time());
                Debug.Log(Time());

                
                
            }

           

            
        }

        IEnumerator Time()
        { yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("SampleScene");
        }

       
        
    }

    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Enemy"))
            {
                mesh.enabled = false;
                joyStick.SetActive(false);
                lossText.SetActive(true);
                audioSource.PlayOneShot(deadSound);
                StartCoroutine(Time());
                

            }

            IEnumerator Time()
        { yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("SampleScene");
        }
    }
    void ScoreSystem()
        {
            scorePoint.text = "Score: " + scoreCount;
        }






 

}

