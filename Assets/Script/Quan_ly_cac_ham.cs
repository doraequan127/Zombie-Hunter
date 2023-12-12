using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quan_ly_cac_ham : MonoBehaviour
{
    public GameObject zombie;
    public AudioClip sound_Background;

    private float lastTime;
    private GameObject Anh_sang, DirectionalLight, ParticleSystem_, Cube;
    private AudioSource audioSource;

    private void Awake()
    {
        Anh_sang = GameObject.Find("Anh_sang");
        DirectionalLight = GameObject.Find("Directional Light");
        ParticleSystem_ = GameObject.Find("Particle System");
        Cube = GameObject.Find("Cube");
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound_Background, 3);
        ParticleSystem_.SetActive(false);
        DirectionalLight.SetActive(false);
        Cube.SetActive(false);
    }

    private void Update()
    {
        if (Time.time > lastTime + 1)
        {
            Vector3 Tọa_độ_zombie = new Vector3(Random.Range(-30f, 30f), zombie.transform.position.y, 10);
            Instantiate(zombie, Tọa_độ_zombie, Quaternion.identity);
            lastTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.L))
            Anh_sang.active = !Anh_sang.active;
        if (Input.GetKeyDown(KeyCode.O))
            DirectionalLight.active = !DirectionalLight.active;
        if (Input.GetKeyDown(KeyCode.P))
            ParticleSystem_.active = !ParticleSystem_.active;
        if (Input.GetKeyDown(KeyCode.I))
            Cube.active = !Cube.active;
    }

    public void button_Exit()
    {
        Application.Quit();
    }
}
