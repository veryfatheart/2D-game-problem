using System.Collections;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public LineRenderer linerenderer;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            BadGuy badguy = hitInfo.transform.GetComponent<BadGuy>();
            if (badguy != null)
            {
                badguy.TakeDamage(damage);
            }

            //Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
                                                     //rotation in a fancy way

            linerenderer.SetPosition(0, firePoint.position);
            linerenderer.SetPosition(1, hitInfo.point);
        }else
        {
            linerenderer.SetPosition(0, firePoint.position);
            linerenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        linerenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        linerenderer.enabled = false;
    }
}
