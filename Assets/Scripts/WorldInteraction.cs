using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    public bool grounded = true;
    public float SilaSkoku = 5;
    Rigidbody rb;
    public float SzybkoscPrzodTyl = 0.5f;
    public float SzybkoscObrotKlawiszami = 30f;
    
    NavMeshAgent playerAgent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAgent = GetComponent<NavMeshAgent>(); 
    }
    IEnumerator SetGrounded()
    {
        yield return new WaitForSeconds(1);
        grounded = true;
    }

    //z tego bedziemy rezygnowali za duzo bledow przy sterowaniu klawiaturą
    private void FixedUpdate()
    {
    /*
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
            grounded = false;
            WlaczWylaczPlayerAgent(OpcjaAgentPlayer.EnableAndIsStopped, false);

            rb.AddForce(0, 250 * SilaSkoku , 0);
            if (rb.useGravity == false) rb.useGravity = true;

            StartCoroutine("SetGrounded");
        }*/
    }
    
    // Update is called once per frame
    void Update () {
        /*
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (Input.GetButton("Horizontal"))
            {
                WlaczWylaczPlayerAgent(OpcjaAgentPlayer.EnableAndIsStopped, false);

                transform.Rotate(new Vector3(0, h * SzybkoscObrotKlawiszami, 0));
            }
            if (Input.GetButton("Vertical"))
            {
                WlaczWylaczPlayerAgent(OpcjaAgentPlayer.EnableAndIsStopped, false);
                transform.Translate(new Vector3(0, 0, v * SzybkoscPrzodTyl * Time.deltaTime));
            }*/


            if (Input.GetMouseButtonDown(0) && grounded == true && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                WlaczWylaczPlayerAgent(OpcjaAgentPlayer.EnableAndIsStopped, true);
                GetInteracion();
            }
	}

    public enum OpcjaAgentPlayer { Enable, IsStopped, EnableAndIsStopped }
    public void StanPlayerAgent()
    {
        if (playerAgent.enabled == false)
        { 
            print("PlayerAgent.Enabled: " + playerAgent.enabled);
            WlaczWylaczPlayerAgent(OpcjaAgentPlayer.Enable, true);
            print("PlayerAgent: " + playerAgent.isStopped);
            WlaczWylaczPlayerAgent(OpcjaAgentPlayer.Enable, false);
        }
        else
        {
            print("PlayerAgent.Enabled: " + playerAgent.enabled);
            print("PlayerAgent.isStopped: " + playerAgent.isStopped);
        }
    }
    
    /// <summary>
    /// Funkcja ON/OFF PlayerAgent.
    /// </summary>
    /// <param name="opc">Która właściwość: Enable,IsStopped,EnableAndIsStopped</param>
    /// <param name="opcja">Włącz lub wyłącz</param>
    public void WlaczWylaczPlayerAgent(OpcjaAgentPlayer opc, bool opcja)
    {
        switch (opc)
        {
            case OpcjaAgentPlayer.Enable:
                switch(opcja)
                {
                    case true:
                        if(playerAgent.enabled == false)
                        {
                            playerAgent.enabled = opcja;
                        }
                        break;
                    case false:
                        if (playerAgent.enabled == true)
                        {
                            playerAgent.enabled = opcja;
                        }
                        break;
                }
                StanPlayerAgent();
                break;
            case OpcjaAgentPlayer.IsStopped:
                switch (opcja)
                {
                    case true:
                        if (playerAgent.enabled == true)
                        {
                            if (playerAgent.isStopped == false)
                            {
                                playerAgent.isStopped = true;
                            }
                        }
                        if(playerAgent.enabled  == false)
                        {
                            playerAgent.enabled = true;
                            if(playerAgent.isStopped == false)
                            {
                                playerAgent.isStopped = true;
                            }
                        }
                        break;
                    case false:
                        if (playerAgent.enabled == true)
                        {
                            if (playerAgent.isStopped == true)
                            {
                                playerAgent.isStopped = false;
                            }
                            playerAgent.enabled = false;
                        }
                        break;
                }
                StanPlayerAgent();
                break;
            case OpcjaAgentPlayer.EnableAndIsStopped:
                switch (opcja)
                {
                    case true:
                        if (playerAgent.enabled == false)
                        {
                            playerAgent.enabled = true;
                            if(playerAgent.isStopped == true)
                            {
                                playerAgent.isStopped = false;
                            }
                        }
                        if(playerAgent.enabled == true)
                        {
                            if (playerAgent.isStopped == true)
                            {
                                playerAgent.isStopped = false;
                            }
                        }
                        break;
                    case false:
                        if (playerAgent.enabled == true)
                        {
                            if (playerAgent.enabled == true)
                            {
                                playerAgent.isStopped = true;
                                playerAgent.enabled = false;
                            }
                        }
                        break;
                }
                
                break;
            default:
                print("Default case, bez akcji.");
                break;
        }
    }

    void GetInteracion()
    {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition); // punkt startowy nacisniecia myszką w świecie
        RaycastHit InteractionInfo; // informacje na co kliknelismy takie jak pozycja i inne
        if(Physics.Raycast(interactionRay,out InteractionInfo, Mathf.Infinity)) //Mathf.Infinity dlugosc promienia Raycast zwraca prawde kiedy promien przecina obiekt z colliderem
        {
            GameObject interactedObject = InteractionInfo.collider.gameObject;
            if(interactedObject.tag == "Interatable Object")
            {
                Debug.DrawLine(interactionRay.origin, InteractionInfo.point);
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0f;
                Debug.DrawLine(interactionRay.origin, InteractionInfo.point);
                playerAgent.destination = InteractionInfo.point;
            }
        }
    }
}
