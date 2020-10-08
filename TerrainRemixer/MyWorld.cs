using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;
using HamstarHelpers.Helpers.Debug;


namespace TerrainRemixer {
	class TerrainRemixerWorld : ModWorld {
		public override void ModifyWorldGenTasks( List<GenPass> tasks, ref float totalWeight ) {
			TerrainRemixerGenPass pass;

			for( int i=0; i<tasks.Count; i++ ) {
				string currPassName = tasks[i].Name;
				pass = TerrainRemixerGenPass.CreatePass(
					currPassName,
					"Adding Noise (before '"+currPassName+"')"
				);

				if( pass != null ) {
					tasks.Insert( i, pass );
					totalWeight += pass.Weight;
					i++;
				}
			}

			pass = TerrainRemixerGenPass.CreatePass(
				"Post Generation",  // denotes end of vanilla list
				"Adding Noise (final)"
			);

			if( pass != null ) {
				tasks.Add( pass );
				totalWeight += pass.Weight;
			}
		}
	}
}
