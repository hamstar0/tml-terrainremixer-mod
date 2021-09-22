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




	public partial class TerrainRemixerAPI : ILoadable {
		/// <summary>
		/// Adds hooks to allow for adjusting (remixing) terrain noise values during gen.
		/// </summary>
		/// <param name="remixer"></param>
		public static void AddTileRemixer( TileRemixer remixer ) {
			var api = ModContent.GetInstance<TerrainRemixerAPI>();

			api.TileRemixers.Add( remixer );
		}


		////////////////

		/// <summary>
		/// Allows adding hooks to dynamically supply gen pass specs (e.g. to supply specs tailored for world size, crimson, etc.).
		/// </summary>
		/// <param name="remixer"></param>
		public static void AddPassHook( Func<TerrainRemixerGenPassSpec> hook ) {
			var api = ModContent.GetInstance<TerrainRemixerAPI>();

			api.PassHooks.Add( hook );
		}
	}
}
