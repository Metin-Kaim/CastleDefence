using UnityEngine;
using System.Collections.Generic;
using Runtime.Abstract.Enemies;
using Runtime.Signals;
using Runtime.Handlers.Turrets;

public class TurretTargetController : MonoBehaviour
{
    public TurretHandler turretHandler;

    private AbsEnemy _currentTarget;
    private List<AbsEnemy> _enemiesInRange = new(); // Turret'�n alg�lad��� d��manlar

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AbsEnemy enemy))
        {
            _enemiesInRange.Add(enemy); // D��man� alg�lananlar listesine ekle
            UpdateTarget(); // Hedefi g�ncelle
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AbsEnemy enemy))
        {
            _enemiesInRange.Remove(enemy); // D��man� alg�lananlar listesinden ��kar
            turretHandler.currentTarget = null;
            UpdateTarget(); // Hedefi g�ncelle
        }
    }

    private void UpdateTarget()
    {
        if (_enemiesInRange.Count != 0) // E�er hi� d��man yoksa hedefi null yap
        {
            // Hedefi null yap
            AbsEnemy nearestEnemy = _enemiesInRange[0]; // En yak�n d��man� varsay�lan olarak ilk d��man yap
            foreach (AbsEnemy enemy in _enemiesInRange)
            {
                // En yak�n d��man� belirleme
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
        // Hedefi g�ncelle
        // nearestEnemy nesnesi art�k turret'�n hedefi olarak atanm�� olacak
    }
}
