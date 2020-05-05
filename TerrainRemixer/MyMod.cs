using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.Misc;
using Terraria.ModLoader;


namespace TerrainRemixer {
	class TerrainRemixerData {
		public bool IsInitialized = false;
	}




	public class TerrainRemixerMod : Mod {
		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-terrainremixer-mod";


		////////////////

		public static TerrainRemixerMod Instance { get; private set; }



		////////////////

		public TerrainRemixerMod() {
			TerrainRemixerMod.Instance = this;
		}

		public override void Load() {
			var data = ModCustomDataFileHelpers.LoadJson<TerrainRemixerData>( this, "data" );

			if( data == null ) {
				data = new TerrainRemixerData();
			}

			if( !data.IsInitialized ) {
				data.IsInitialized = true;
				TerrainRemixerConfig.Instance.Initialize();
			}

			if( !ModCustomDataFileHelpers.SaveAsJson<TerrainRemixerData>(this, "data", true, data) ) {
				LogHelpers.Warn( "Could not save Terrain Modifier data." );
			}
		}

		public override void Unload() {
			TerrainRemixerMod.Instance = null;
		}
	}
}