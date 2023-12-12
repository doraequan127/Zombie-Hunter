using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioClip sound_ShotGun;

    private Vector3 target;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   //Nhớ add tag "MainCamera" vào Main Camera
        //Hoặc có thể tạo Ray tùy ý :  Ray ray = new Ray(điểm_đầu, điểm_đến);
		//ray.GetPoint(5) :  trả về vị trí của điểm cách gốc của ray 1 khoảng là 5 đơn vị
		RaycastHit hit;
        if (Physics.Raycast(ray, out hit))     //Physics.Raycast(ray, out hit, 3): số 3 ở đây là maxDistance, nghĩa là tia ray chỉ bắn ra 3m thì dừng
            target = hit.point;       //Ngoài lề: hit.distance là độ dài từ điểm đầu đến điểm cuối của ray
        transform.LookAt(target);
        transform.Rotate(new Vector3(0, 89));
		
		//Thực ra ko cần dùng Raycast, ta có thể dùng hàm OnMouseDown(), OnMouseOver(),... có sẵn trên Unity
		//Hàm này phải viết trong script của gameobject ta cần click. Ví dụ ta muốn click vào con zombie thì nó sẽ bị tiêu diệt thì ta phải viết hàm OnMouseDown() vào file Zombie.cs
		//Hàm này chỉ dùng cho chuột máy tính, chưa chắc đã dùng đc cảm ứng trên iphone, smartphone

		//Trong game 2D thì hàm Physics.Raycast() hơi khác 1 tí: https://learn.unity.com/tutorial/world-interactions-dialogue-raycast?courseId=5c5c1e08edbc2a5465c7ec01&projectId=5c6166dbedbc2a0021b1bc7c#5c7f8528edbc2a002053b3bf (mục 2)

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(sound_ShotGun);
            if (hit.transform.name == "Zombie(Clone)")
                Destroy(hit.transform.gameObject);
        }
    }
}
