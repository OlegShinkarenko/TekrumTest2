using UnityEngine;
using System.Collections;

public class ShootingScr : MonoBehaviour
{

    public float ShootSpeed;
    public Transform bullet;

    int flag = 0;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Transform BulletInstance = (Transform)Instantiate(bullet, transform.position, Quaternion.identity);
                BulletInstance.GetComponent<Rigidbody>().AddForce(hit.point * 300);
            }

            Destroy(GameObject.Find("Bullet(Clone)"), 0.5f);
        }
            


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    flag++;

                    if (flag == 1)
                    {
                        anim.SetTrigger("Sp");   
                    }
                    if (flag == 2)
                    {
                        anim.SetTrigger("Dt");
                        flag = 0;
                    }

                }

    }
}
