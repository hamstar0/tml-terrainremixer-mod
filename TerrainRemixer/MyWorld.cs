using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;
using ModLibsCore.Libraries.Debug;


namespace TerrainRemixer {
	class TerrainRemixerWorld : ModWorld {
		public override void ModifyWorldGenTasks( List<GenPass> tasks, ref float totalWeight ) {
			TerrainRemixerGenPass pass;

			for( int i=0; i<tasks.Count; i++ ) {
				string currPassName = tasks[i].Name;
				pass = TerrainRemixerGenPass.CreatePass( currPassName, false );

				if( pass != null ) {
					tasks.Insert( i, pass );
					totalWeight += pass.Weight;
					i++;
				}
			}

			pass = TerrainRemixerGenPass.CreatePass(
				"Post Generation",  // denotes end of vanilla list
				true
			);

			if( pass != null ) {
				tasks.Add( pass );
				totalWeight += pass.Weight;
			}
		}
	}
}
