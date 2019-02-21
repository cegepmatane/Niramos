﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieJoueur : MonoBehaviour
{
    [SerializeField]
    private float vie = 100;
    [SerializeField]
    private float vieMax = 100;

    private void OnEnable()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hit " + collision.gameObject.name);
    }
    public void faireDegat(float quantiter)
    {
        vie -= quantiter;
        if (vie <= 0) {
            GestionnaireMort.getEvent().Invoke(this);
        }
        GestionnaireEvenement.declancherEvenement("vieChanger");
        this.playDamageSound();
        //Debug.Log(this.gameObject.name + " " + vie);
    }

    public void regenererVie(float quantiter)
    {
        vie += quantiter;
        if (vie > vieMax) vie = vieMax;
        GestionnaireEvenement.declancherEvenement("vieChanger");
    }

    public void setVieAuMaximum() {
        this.vie = this.vieMax;
    }

    public float getVie()
    {
        return vie;
    }

    public float getVieMaximale() {
        return this.vieMax;
    }

    private void playDamageSound() {
        AudioScript aScript = this.gameObject.GetComponent<AudioScript>();
        if(aScript) {
            AudioSource dmgSound = aScript.getFirstSound();
            if (dmgSound) {
                dmgSound.Play();
            }
            else {
                Debug.LogWarning("WARN    VieJoueur:playDamageSound(): Sound not found.");
            }
        }
        else {
            Debug.LogWarning("WARN    VieJoueur:playDamageSound(): No AudioScript found for this player.");
        }
    }
}
