using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shotPointTransform;
    [SerializeField] private float timeBeetweenShots;
    private float shotTime;

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Вычисляем направление, разница между позицией нажатия мыши и позицией оружия
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Находим угол
        Quaternion newRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);//конвертируем угол в поворот юнити
        transform.rotation = newRotation;

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(projectilePrefab, shotPointTransform.position, shotPointTransform.rotation);
                shotTime = Time.time + timeBeetweenShots;
            }
        }
    }
}
