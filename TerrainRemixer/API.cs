using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using ModLibsCore.Classes.Loadable;


namespace TerrainRemixer {
	/// <summary>
	/// Hooks tile 'remixing'.
	/// </summary>
	/// <param name="passSpec"></param>
	/// <param name="tileX"></param>
	/// <param name="tileY"></param>
	/// <param name="noiseStrengthPercent">Percent amount to apply the noise value.</param>
	/// <param name="noiseValue">Random value for the given tile generated via. noise algorithm.</param>
	/// <returns>`false` to permit default behavior (run other remixers, tile check against config thresholds).</returns>
	public delegate bool TileRemixer(
		TerrainRemixerGenPassSpec passSpec,
		int tileX,
		int tileY,
		ref float noiseStrengthPercent,
		ref float noiseValue );




	public class TerrainRemixerAPI : ILoadable {
		public static void AddTileRemixer( TileRemixer remixer ) {
			var api = ModContent.GetInstance<TerrainRemixerAPI>();

			api.TileRemixers.Add( remixer );
		}


		////////////////
		
		internal static bool ApplyTileRemixers(
					TerrainRemixerGenPassSpec passSpec,
					int tileX,
					int tileY,
					ref float noiseStrength,
					ref float randVal ) {
			var api = ModContent.GetInstance<TerrainRemixerAPI>();

			foreach( TileRemixer remixer in api.TileRemixers ) {
				if( remixer(passSpec, tileX, tileY, ref noiseStrength, ref randVal) ) {
					return true;
				}
			}

			return false;
		}



		////////////////

		private IList<TileRemixer> TileRemixers = new List<TileRemixer>();



		////////////////

		void ILoadable.OnModsLoad() { }
		void ILoadable.OnModsUnload() { }
		void ILoadable.OnPostModsLoad() { }
	}
}
