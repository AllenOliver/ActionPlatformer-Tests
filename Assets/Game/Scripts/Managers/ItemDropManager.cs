using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum ITEM_TYPE
{
    HEALTH,
    GOLD
}

public class ItemDropManager : MonoBehaviour
{
    public static ItemDropManager instance;
    public GameObject HealthPickup;
    public GameObject GoldPickup;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void SpawnHealthPickup(Transform location) => Instantiate(HealthPickup, location.position, Quaternion.identity);

    public void SpawnGoldPickup(Transform location) => Instantiate(GoldPickup, location.position, Quaternion.identity);

    public GameObject SpawnRandomItemDrop(Transform location)
    {
        var item = Random.Range(0, (int)ITEM_TYPE.GOLD);
        switch (item)
        {
            case 0:
                return HealthPickup;

            case 1:
                return GoldPickup;

            default:
                return null;
        }
    }
}