using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using ModLibsCore.Classes.Loadable;


namespace TerrainRemixer {
	public partial class TerrainRemixerAPI : ILoadable {
		internal static bool ApplyTileRemixers(
					TerrainRemixerGenPassSpec passSpec,
					int tileX,
					int tileY,
					ref float noiseStrength,
					ref float randVal ) {
			var api = ModContent.GetInstance<TerrainRemixerAPI>();

			foreach( TileRemixer remixer in api.TileRemixers ) {
				if( remixer( passSpec, tileX, tileY, ref noiseStrength, ref randVal ) ) {
					return true;
				}
			}

			return false;
		}

		internal static IEnumerable<TerrainRemixerGenPassSpec> GetCustomPasses() {
			var api = ModContent.GetInstance<TerrainRemixerAPI>();

			foreach( Func<TerrainRemixerGenPassSpec> hook in api.PassHooks ) {
				TerrainRemixerGenPassSpec spec = hook.Invoke();
				if( spec != null ) {
					yield return spec;
				}
			}
		}



		////////////////

		private IList<Func<TerrainRemixerGenPassSpec>> PassHooks = new List<Func<TerrainRemixerGenPassSpec>>();

		private IList<TileRemixer> TileRemixers = new List<TileRemixer>();



		////////////////

		void ILoadable.OnModsLoad() { }
		void ILoadable.OnModsUnload() { }
		void ILoadable.OnPostModsLoad() { }
	}
}
