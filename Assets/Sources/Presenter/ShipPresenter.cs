using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;
  
    public void Init(Root init)
    {
        _init = init;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _init.Ship.Lifes--;
            if (_init.Ship.Lifes == 0)
            _init.DisableShip();
        }
    }
}
