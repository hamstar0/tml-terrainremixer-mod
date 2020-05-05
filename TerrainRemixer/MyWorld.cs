using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;
using HamstarHelpers.Helpers.Debug;


namespace TerrainRemixer {
	class TerrainRemixerWorld : ModWorld {
		public override void ModifyWorldGenTasks( List<GenPass> tasks, ref float totalWeight ) {
			int idx = tasks.FindIndex( t => t.Name == "Terrain" );
			if( idx == -1 ) {
				idx = 1;
			}

			var pass = new TerrainRemixerGenPass();

			tasks.Insert( idx + 1, pass );

			totalWeight += pass.Weight;
		}
	}
}
