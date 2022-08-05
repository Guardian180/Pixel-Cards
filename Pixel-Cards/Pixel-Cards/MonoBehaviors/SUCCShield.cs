using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Sonigon;
using Sonigon.Internal;
using SoundImplementation;
using UnboundLib;
using UnboundLib.Utils;
using UnityEngine;

namespace PX.MonoBehaviors
{
	// Token: 0x02000012 RID: 18
	public class SuccMono : MonoBehaviour
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00003F2C File Offset: 0x0000212C
		private void Start()
		{
			this.player = base.GetComponent<Player>();
			this.block = base.GetComponent<Block>();
			this.data = base.GetComponent<CharacterData>();
			this.ResetEffectTimer();
			this.ResetTimer();
			this.canTrigger = true;
			this.hasTriggered = false;
			this.basic = this.block.BlockAction;
			this.numcheck = 0;
			if (this.block)
			{
				this.succ = new Action<BlockTrigger.BlockTriggerType>(this.GetDoBlockAction(this.player, this.block).Invoke);
				this.block.FirstBlockActionThatDelaysOthers = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(this.block.FirstBlockActionThatDelaysOthers, this.taser);
				this.block.delayOtherActions = true;
			}
		}
		public void Destroy()
		{
			Object.Destroy(this);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003FF9 File Offset: 0x000021F9
		public void OnDestroy()
		{
			this.block.BlockAction = this.basic;
		}
