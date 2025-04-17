using System.Collections.Generic;
using UnityEngine;

namespace McDonaldsValuables
{
    public class IceCream : MonoBehaviour
    {
        public bool Debug;

        private ItemToggle itemToggle;

        private void Start()
        {
            itemToggle = GetComponent<ItemToggle>();
        }


        public void Cone()
        {
            int randomIndex = Random.Range(0, 2); 
            switch (randomIndex)
            {
                case 0:
                    ApplyUpgrade();
                    break;
                case 1:
                    KillPlayer();
                    break;
            }
        }

        private void ApplyUpgrade()
        {
            string steamID = SemiFunc.PlayerGetSteamID(SemiFunc.PlayerAvatarGetFromPhotonID(itemToggle.playerTogglePhotonID));

            PunManager.instance.UpgradeMapPlayerCount(steamID);
            PunManager.instance.UpgradePlayerEnergy(steamID);
            PunManager.instance.UpgradePlayerExtraJump(steamID);
            PunManager.instance.UpgradePlayerGrabRange(steamID);
            PunManager.instance.UpgradePlayerGrabStrength(steamID);
            PunManager.instance.UpgradePlayerThrowStrength(steamID);
            PunManager.instance.UpgradePlayerHealth(steamID);
            PunManager.instance.UpgradePlayerSprintSpeed(steamID);
            PunManager.instance.UpgradePlayerTumbleLaunch(steamID);  

            if (Debug)
                McDonaldsValuables.Logger.LogMessage("Upgrades applied");
        }

        private void KillPlayer()
        {
            if (SemiFunc.IsMultiplayer())
            {
                ChatManager.instance.PossessSelfDestruction();
            }
            else
            {
                PlayerAvatar.instance.playerHealth.health = 0;
                PlayerAvatar.instance.playerHealth.Hurt(1, savingGrace: false);
            }

            if (Debug)
                McDonaldsValuables.Logger.LogMessage("Player killed");
        }
    }
}
