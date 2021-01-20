using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float cooldown = 1;

    private Inventory inventory;

    private bool canShoot = true;

    private float nextTime;

    private float checkDelay = 0.5f;

    private float nextCheckTime;

    public PlayerProjectile projectile;

    public AudioClip ThrowRock;

    List<string> tags;


    private void Awake()
    {
        nextTime = Time.time;
        nextCheckTime = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        tags = new List<string>();
        foreach (Slot slot in inventory.slots)
        {
            tags.Add(slot.tag);
        }

        if (nextCheckTime < Time.time)
        {
            canShoot = true;
            nextCheckTime = Time.time + checkDelay;
        }
        if (nextTime < Time.time && canShoot && isStoneSelected() && Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(ThrowRock);
            PlayerProjectile pro = GameObject.Instantiate<PlayerProjectile>(projectile, transform.position, Quaternion.identity, null);
            pro.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);

            int i = tags.IndexOf("Rock");

            Events.RemoveItem(i);


            nextTime = Time.time + cooldown;
            canShoot = false;
        }
    }


    private bool isStoneSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && slot.tag == "Rock") return true;
        }
        return false;
    }
}
