using System;
using UnityEngine;

namespace PixelCards.MonoBehaviours
{
	// Token: 0x02000007 RID: 7
	internal class HungryBlock_Mono : MonoBehaviour
	{
		// Token: 0x06000015 RID: 21 RVA: 0x0000250D File Offset: 0x0000070D
		private void Start()
		{
			this._player = base.GetComponentInParent<Player>();
			this.isLow = false;
			this.punish = 5;
			this.damage = 15;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002534 File Offset: 0x00000734
		private void Update()
		{
			bool flag = this._player.data.block.sinceBlock > this._player.data.block.Cooldown() && this.lastblocks > 0;
			if (flag)
			{
				this.lastblocks = 0;
				foreach (Player player in PlayerManager.instance.players)
				{
					
				}
			}
			bool flag2 = this._player.data.block.IsOnCD() && this._player.data.health >= (float)(this.damage + this.lastblocks);
			if (flag2)
			{
				bool flag3 = this.isLow;
				if (flag3)
				{
					this._player.data.block.ResetCD(true);
					this.isLow = false;
				}
				else
				{
					this._player.data.healthHandler.TakeDamage(Vector2.up * (float)(this.damage + this.lastblocks * this.punish), this._player.data.block.blockedAtPos, null, null, false, true);
					foreach (Player player2 in PlayerManager.instance.players)
					{
						
					}
					this._player.data.block.ResetCD(false);
					this.isLow = false;
					this.lastblocks++;
				}
			}
			else
			{
				bool flag4 = this._player.data.health < (float)(this.damage + this.lastblocks * this.punish);
				if (flag4)
				{
					this._player.data.block.counter = 0f;
					this.isLow = true;
				}
				else
				{
					bool flag5 = !this._player.data.block.IsOnCD();
					if (flag5)
					{
						this.isLow = false;
					}
				}
			}
		}

		// Token: 0x04000011 RID: 17
		private Player _player;

		// Token: 0x04000012 RID: 18
		private int damage;

		// Token: 0x04000013 RID: 19
		private int punish;

		// Token: 0x04000014 RID: 20
		private bool isLow;

		// Token: 0x04000015 RID: 21
		private int lastblocks;
	}
}
