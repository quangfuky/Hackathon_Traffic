using UnityEngine;
using System.Collections;

public enum CAR_DIRECTION
{
    //BACK = 1,
    FRONT = 2,
    LEFT = 3,
    RIGHT = 5
}
public class CCar : MonoBehaviour {
    public bool canMove = true;
    public CAR_DIRECTION direction = CAR_DIRECTION.FRONT;

    public float rotation = 0.0f;
    public float speedRotation =1.0f;

    public float speedMove = 1.0f;
    private float angleStart =0.0f;

    private bool isCollided = false;
	// Use this for initialization
	void Start () {
        rotation = transform.eulerAngles.y;
        angleStart = rotation;
        Debug.Log(rotation);
	}

    public IEnumerator StartMove()
    {
        while(true)
        {
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMove();
	}
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public void UpdateMove()
    {
        if(canMove)
        {
            switch(direction)
            {
                case CAR_DIRECTION.FRONT:
                    gameObject.transform.position += transform.forward * speedMove *Time.deltaTime;
                    break;
                case CAR_DIRECTION.LEFT:
                        if(rotation <= (angleStart - 90))
                        {
                            direction = CAR_DIRECTION.FRONT;
                        }
                        rotation -= speedRotation * Time.deltaTime;
                        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z));
                        // move
                        transform.position += transform.forward *Time.deltaTime*speedMove;
                    break;
                case CAR_DIRECTION.RIGHT:
                    if(rotation >= (angleStart + 90))
                        {
                            direction = CAR_DIRECTION.FRONT;
                        }
                        rotation += speedRotation * Time.deltaTime;
                        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z));
                        // move
                        transform.position += transform.forward *Time.deltaTime*speedMove;
                    break;
            }
        }
    }
    public GameObject objTest;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "CheckPoint" && !isCollided)
        {
            CheckPoint StateLight = col.GetComponent<CheckPoint>();
            Debug.Log(StateLight.canGo);
            // check xem den xanh hay do
            if (StateLight.canGo)
            {
                 canMove = true;
            }
            else
            {
                Debug.Log("den do");
                
                // random co vuot den do hay ko 
                bool violation = RandomViolation();
                Debug.Log("vi pham:" + violation);
                if (violation) // if true : vuot den do
                {
                    canMove = true;
                    if(objTest)
                    {
                        objTest.SetActive(true);
                    }
                }
                else
                {
                    canMove = false;
                    Invoke("ChangeStateMove", 3);
                }
            }
            isCollided = true;
        }
    }

    void ChangeStateMove()
    {
        direction = GetRandomEnum<CAR_DIRECTION>();
        canMove = true;
    }

    // true : vi pham
    // false : khong vi pham
    public bool RandomViolation()
    {
        int rand = Random.Range(0, 100);
        Debug.Log("rand:"+rand);
        if (rand < 50)
        {
            return false;
        }
        else
            return true;
    }
}
