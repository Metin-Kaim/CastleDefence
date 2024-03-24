using UnityEngine;
using System.Collections.Generic;
using Runtime.Abstract.Enemies;
using Runtime.Signals;
using Runtime.Handlers.Turrets;

public class TurretTargetController : MonoBehaviour
{
    public TurretHandler turretHandler;

    private AbsEnemy _currentTarget;
    private List<AbsEnemy> _enemiesInRange = new(); // Turret'ýn algýladýðý düþmanlar

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AbsEnemy enemy))
        {
            _enemiesInRange.Add(enemy); // Düþmaný algýlananlar listesine ekle
            UpdateTarget(); // Hedefi güncelle
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AbsEnemy enemy))
        {
            _enemiesInRange.Remove(enemy); // Düþmaný algýlananlar listesinden çýkar
            turretHandler.currentTarget = null;
            UpdateTarget(); // Hedefi güncelle
        }
    }

    private void UpdateTarget()
    {
        if (_enemiesInRange.Count != 0) // Eðer hiç düþman yoksa hedefi null yap
        {
            // Hedefi null yap
            AbsEnemy nearestEnemy = _enemiesInRange[0]; // En yakýn düþmaný varsayýlan olarak ilk düþman yap
            foreach (AbsEnemy enemy in _enemiesInRange)
            {
                // En yakýn düþmaný belirleme
                if (enemy.Index < nearestEnemy.Index)
                {
                    nearestEnemy = enemy;
                }
            }
            _currentTarget = nearestEnemy;
        }
        else
        {
            _currentTarget = null;
        }

        turretHandler.currentTarget = _currentTarget;
        // Hedefi güncelle
        // nearestEnemy nesnesi artýk turret'ýn hedefi olarak atanmýþ olacak
    }
}
