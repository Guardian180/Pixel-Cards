using UnityEngine;
using ModdingUtils.MonoBehaviours;
using UnboundLib.Cards;
using UnboundLib;
using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using PixelCards.Cards;


namespace PixelCards.MonoBehaviours
{
    internal class Succ : MonoBehaviour
    {
        private void Start()
        {
            this.player = base.GetComponentInParent<Player>();
            this.block = base.GetComponent<Block>();
            this.damage = 15;
        }

        private void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            foreach (Player player in PlayerManager.instance.players)
            {
                this.player.data.health -= damage;
                DealDamageToPlayer.TargetPlayer Player;
            }



        }
        private void OnOnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
        }
        public Block block;
        public int damage;
        public Player player;
    }
}