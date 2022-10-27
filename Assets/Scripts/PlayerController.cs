using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set public access objects
    public float speed;
    public float minX, maxX, minY, maxY;
    public GameObject laser, laserSpawn;
    public  float fireRate = 0.25f;
    // Set private access objects
    private Rigidbody2D rBody;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        // Initial Game Boundaries
        minX = -8f;
        maxX = 8f;
        minY = -4f;
        maxY = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        // GET LOCATION OF OBJECT
        
        float horizontalMovement, verticalMovement;

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        // ADD VELOCITY TO MOVE

        Vector2 newVelocity = new Vector2(horizontalMovement, verticalMovement);
        rBody.velocity = newVelocity * speed;

        // Restrict player from leaving field boundary
        float newX, newY;
        newX = Mathf.Clamp(rBody.position.x, minX, maxX);
        newY = Mathf.Clamp(rBody.position.y, minY, maxY);

        rBody.position = new Vector2(newX, newY);

        // ADD LASER FIRE ACTION

        // Check if fire1 button activated/pressed
        if (Input.GetAxis("Fire1") > 0 && timer > fireRate) 
        {
            // If yes, instantiate/spawn laser (what, when, rotation)
            GameObject gObj;
            gObj = GameObject.Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            gObj.transform.Rotate(new Vector3(0, 0, 90));

            // Reset time 
            timer = 0;
        }
        timer += Time.deltaTime;

    }
}