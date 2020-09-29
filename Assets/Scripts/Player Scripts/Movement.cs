
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float speed;

    //private float h, v;

    private float min_Y = -4.46f;
    private float max_Y = 6.44f;
    private float min_X = -5.88f;
    private float max_X = 5.81f;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

   

    public void FixedUpdate()
    {
        MovePlayer();


    }

    private void MovePlayer()
    {
       /* h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(v > max_Y) 
        {
            v = max_Y;
        }
        else if (v < min_Y)
        {
            v = min_Y;
        }

        if (h > max_X)
        {
            h = max_X;
        }
        else if (h < min_X)
        {
            h = min_X;
        }


        Vector2 movement = new Vector2(h, v) * speed * Time.fixedDeltaTime;

        rb.velocity = movement;*/

        if(Input.GetAxisRaw("Vertical") > 0.0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.fixedDeltaTime;

            if(temp.y > max_Y)
            {
                temp.y = max_Y;
            }

            transform.position = temp;
        } else if ( Input.GetAxisRaw("Vertical") < 0.0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.fixedDeltaTime;

            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }

            transform.position = temp;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.fixedDeltaTime;

            if (temp.x > max_X)
            {
                temp.x = max_X;
            }

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.fixedDeltaTime;

            if (temp.x < min_X)
            {
                temp.x = min_X;
            }

            transform.position = temp;
        }
    }



}
