// nameSpace area
using UnityEngine;
using UnityEngine.InputSystem;

// format accessModifier class  ClassName : Inheritance
public class PlayerScript : MonoBehaviour
{
    // Creating object instance of Rigidbody class
    // format acessModifier ClassName object; (object is instance of class)
    private Rigidbody rb;

    // Creating float variable for convert our vector2 value into vector3 because object.method(Vector3); only use Vector3 
    private float movementX;
    private float movementZ;


    // add variable for boost movement speed
    private float movementSpeed =1.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    // this method not return any value
    // method using InputValue Class as argument parameter
    // then use to plass input value to other struct variable
    // InputValue is class and inputValue is instance of class we call as object
    public void OnMove(InputValue inputValue)
    { 
        // format struct variableName = object.method<T>();
        Vector2 MovementVector =  inputValue.Get<Vector2>();

        // Converting (struct)vector2 variable into float variable value by specifying struct_instance.fields example: struct_instance.y 
        movementX = MovementVector.x;
        Debug.Log(MovementVector);
        Debug.Log(movementZ);
        movementZ = MovementVector.y;
    }


    void Update()
    {
        
        // rigidbody only allow Vactor3 value so we converting by 
        // struct variableName = ((new) iniziate to allocate memory in ram for store ) datatype struct(x,y,z);   
        Vector3 threeAxisVAlue = new Vector3(movementX,0f,movementZ);
        
        // adding force to the GameObject by altering its rigidbody values
        // format object.method(argument parameter)
        rb.AddForce(threeAxisVAlue * movementSpeed);
    }
}
