using HamstarHelpers.Helpers.Debug;
using Terraria.ModLoader;


namespace TerrainRemixer {
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
		}

		public override void Unload() {
			TerrainRemixerMod.Instance = null;
		}
	}
}