using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankChangeController : MonoBehaviour
{
    public List<Tank> Tanks = new List<Tank>();
    public Transform TanksContainer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            var currentTank = FindObjectOfType<Tank>();
            var newTank = GentNextTank(currentTank, Input.GetKeyDown(KeyCode.Q));

            newTank.transform.position = currentTank.transform.position;
            newTank.transform.rotation = currentTank.transform.rotation;
            newTank.gameObject.SetActive(true);
            newTank.transform.SetParent(null);

            currentTank.transform.localPosition = Vector3.zero;
            currentTank.transform.SetParent(TanksContainer);
            currentTank.gameObject.SetActive(false);

            GameData.Instance.player.Tank = newTank;
            GameData.Instance.player.OnTankChanged?.Invoke();
        }
    }

    private Tank GentNextTank(Tank current, bool backward = false)
    {
        int currentItemIndex = Tanks.IndexOf(current);
        int nextItemIndex = currentItemIndex == Tanks.Count - 1 ? 0 : currentItemIndex + 1;

        if (backward)
            nextItemIndex = currentItemIndex == 0 ? Tanks.Count - 1: currentItemIndex - 1;

        var result = Tanks[nextItemIndex];
        return result;
    }
}
