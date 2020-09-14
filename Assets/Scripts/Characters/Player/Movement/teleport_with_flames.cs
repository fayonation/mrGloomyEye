using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_with_flames : MonoBehaviour
{

    public Transform player;
    private ParticleSystem ps;
    ParticleSystem.EmissionModule emissionModule;
    float theDiminishingRate = 65;


    // movement stuff

    public float speed = 50f;
    public Vector2 target;
    Vector2 mousePosition;
    bool wsel = false;
    // end of movement stuff

    // Start is called before the first frame update
    void Start()
    {
        // movement stuff
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        target.x = worldPosition.x;
        target.y = worldPosition.y;
        /// end of movement stuff

        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        emissionModule = ps.emission;
    }
    private void Update()
    {

        //  start of movement stuff
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (
            transform.position.x >= target.x - 5 && transform.position.x <= target.x + 5 &&
            transform.position.y >= target.y - 5 && transform.position.y <= target.y + 5 &&
            !wsel)
        {
            Destroy(GetComponent<Collider2D>());
            wsel = true;
            CircleCollider2D newCollider = gameObject.AddComponent<CircleCollider2D>();
            newCollider.radius = .5f;
            newCollider.offset = new Vector2(.3f, 0);
        }
        //end of movement stuff
        Invoke("diminishFlames", 5); // start diminishing after 5 seconds
    }
    void diminishFlames()
    {
        theDiminishingRate = theDiminishingRate - 1;
        emissionModule.rate = theDiminishingRate;
        if (theDiminishingRate <= 0)
            Destroy(gameObject, 1f);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "teleportSpot")
        {
            player = GameObject.Find("Player").transform;
            var teleAnim = other.transform.GetChild(0).GetComponent<Animator>();
            teleAnim.SetTrigger("teleporting");
            player.position = new Vector3(other.transform.position.x, other.transform.position.y + 6, 0);
        }

    }


}
