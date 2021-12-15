using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float rotateTo, tempRot, maxSpeed = 8f, accelertion = 0;
    private float maxHeight = 4.9f, minHeight = 0.6f;
    private int scored = 0;
    private Text scorePopUp, scoreText;
    private float leftLimit = -10.0f, rightLimit = 10.0f, leftSpeed, rightSpeed; //TODO: Need to add these in code
    Color c;
    public Animator anim;
    private Transform snowFallPs, airPS;
    Touch touch;
    public void InitializeLevel(float maxHeight, float minHeight, Transform additinalPS = null)
    {
        this.maxHeight = maxHeight;
        this.minHeight = minHeight;
        //if (SceneManager.GetActiveScene().name == "Level2")
        //{
        snowFallPs = additinalPS;//GameObject.Find("SnowParticles").GetComponent<Transform>();
        //}
        absVal = 10.0f;
        airPS = GameObject.Find("AirParticles").GetComponent<Transform>();
        airPS.gameObject.SetActive(false);
        audio.Play();
        audio.Pause();
    }
    Vector2 limitXY;
    float absVal, rotateVal;
    bool rotate;
    RaycastHit hit;
    Quaternion rot;
    bool accelerated = false;
    public GameObject[] rampObj;
    private bool jumped = false;
    public AudioSource audio;
    void Update()
    {
        if (transform.position.z > 2.0f)
            airPS.gameObject.SetActive(true);
        else
            airPS.gameObject.SetActive(false);

        limitXY = new Vector2(0.9f, 0.9f);
        float moveVertical = Input.GetAxis("Vertical");
        rampObj = GameObject.FindGameObjectsWithTag("Ramp");

        Vector3 p1 = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 p2 = p1 - (Vector3.forward * 2);
        if (Physics.CapsuleCast(p1, p2, 2, transform.forward, out hit, 5))//if (Physics.SphereCast(transform.position, 2.0f, transform.forward, out hit, 2))//if (Physics.BoxCast(new Vector3(gameObject.transform.position.x / 2, gameObject.transform.position.y / 2, gameObject.transform.position.z / 2), transform.localScale, transform.forward, out hit, transform.rotation, 1))
        {
            if (hit.collider.tag == "Ramp")
            {
                jumped = true;
                transform.position = new Vector3(hit.transform.position.x, transform.position.y, transform.position.z);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-25.0f, 0, 0), (50));
            }
            else if (hit.collider.tag == "RR")
            {
                Debug.Log("Hittt");
            }
            else if (hit.collider.tag == "Rocks")
            {
                audio.Play();
            }
        }
        else
        {
            audio.Pause();
        }


        if (jumped)
        {
            transform.position += new Vector3(0, 25 * Time.deltaTime, 50 * Time.deltaTime);
            if (transform.position.y >= maxHeight)
                jumped = false;
        }
        if (jumped == false)
        {
            if (transform.position.y > minHeight)
                transform.position -= new Vector3(0, 7 * Time.deltaTime, 0);
            else if (transform.position.y <= minHeight)
            {
                if (transform.position.z > 0)
                    transform.position = new Vector3(transform.position.x, minHeight, transform.position.z - (maxSpeed * Time.deltaTime));
            }
        }
        //if (jumped == false &&)

        //if (transform.position.y < 0.1 && jumped == false)
        //  jumped = true;

    }

    void FixedUpdate()
    {
        rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), (50 * Time.deltaTime));

#if UNITY_EDITOR
        if (transform.position.y <= minHeight)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x > leftLimit)
                {
                    transform.position = new Vector3(transform.position.x - absVal * Time.deltaTime, transform.position.y, transform.position.z);
                    rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -20, -5), (50 * Time.deltaTime));
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x < rightLimit)
                {
                    transform.position = new Vector3(transform.position.x + absVal * Time.deltaTime, transform.position.y, transform.position.z);
                    rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 20, 5), (50 * Time.deltaTime));
                }
            }
        }

#elif UNITY_ANDROID
        if (transform.position.y <= minHeight)
        {
            Vector3 dir = Vector3.zero;
            dir.x = Input.acceleration.x;
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            dir *= 20 * Time.deltaTime ;
            transform.position = new Vector3(Mathf.Clamp( transform.position.x + dir.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
            //if (dir.x < 0)
            //{
            //    if (transform.position.x > leftLimit)
            //    {
            //        dir *= Time.deltaTime;
            //        transform.Translate(dir * 20);
            //    }
            //}
            //if (dir.x > 0)
            //{
            //    if (transform.position.x < rightLimit)
            //    {
            //        dir *= Time.deltaTime;
            //        transform.Translate(dir * 20);
            //    }
            //}
            //if (Input.touchCount > 0)
            //{
            //    touch = Input.GetTouch(0);
            //    if (touch.phase == TouchPhase.Stationary | touch.phase == TouchPhase.Moved)
            //    {
            //        if (touch.position.x < Screen.width / 2)
            //        {
            //            if (transform.position.x > leftLimit)
            //            {
            //                transform.position = new Vector3(transform.position.x - absVal * Time.deltaTime, transform.position.y, transform.position.z);
            //                rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -20, -5), (50 * Time.deltaTime));
            //            }
            //        }
            //        if (touch.position.x > Screen.width / 2)
            //        {
            //            if (transform.position.x < rightLimit)
            //            {
            //                transform.position = new Vector3(transform.position.x + absVal * Time.deltaTime, transform.position.y, transform.position.z);
            //                rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 20, 5), (50 * Time.deltaTime));
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    if (transform.position.x < 0)
            //        transform.Translate(absVal * Time.deltaTime, 0, 0);

            //    if (transform.position.x > 0)
            //        transform.Translate(-absVal * Time.deltaTime, 0, 0);
            //}
        }
#endif
        if (snowFallPs)
            snowFallPs.position = this.transform.position * Time.deltaTime;

        transform.rotation = rot;
    }

    void OnDrawGizmos()
    {
        Vector3 p1 = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 p2 = p1 - (Vector3.forward * 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p1, 2);
        Gizmos.DrawSphere(p2, 2);
    }
}