using UnityEngine;
using Asteroids.Model;
using System.Drawing.Text;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;

    private int _index;
    private float _secondsPerIndex = 1f;
    private Nlo _NloModel_1;
    private Nlo _NloModel_2;

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 70)
        {
            _NloModel_1 = new Nlo( GetRandomPositionOutsideScreen(), Config.NloSpeed, _init.Ship);
            _NloModel_2 = new Nlo(GetRandomPositionOutsideScreen(), Config.NloSpeed, _init.Ship);
            _NloModel_1.SetEnemy(_NloModel_2);
            _NloModel_2.SetEnemy(_NloModel_1);
            _factory.CreateNlo(_NloModel_1);
            _factory.CreateNlo(_NloModel_2);
            
        }
        else
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}
