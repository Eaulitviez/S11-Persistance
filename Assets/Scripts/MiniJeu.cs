using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScorePanneau;
    [SerializeField] GameObject panneauRecord;
    public TMP_InputField inputNom;

    void Start()
    {
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }
    public void TraiterDefaite()
    {
        Debug.Log("Défaite");
        float recordActuel = PlayerPrefs.GetFloat("meilleurScore", 0f);
        if (pointageTemps >= recordActuel)
        {
            Invoke("MontrerPanneauNouveauRecord", 3f);
        }
    }
    void MontrerPanneauNouveauRecord()
    {
        Debug.Log("NOUVEAU RECORD!");
        panneauRecord.SetActive(true);
        textScorePanneau.text = textScore.text;
    }
    public void EnregistrerNomRecord()
    {
        string nom = inputNom.text;
        PlayerPrefs.SetString("nom", nom);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
