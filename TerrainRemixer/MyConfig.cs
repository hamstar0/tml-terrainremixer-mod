using System;
using System.Collections.Generic;
using Terraria.ModLoader.Config;
using HamstarHelpers.Services.Configs;
using HamstarHelpers.Classes.UI.ModConfig;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.DotNET.Reflection;


namespace TerrainRemixer {
	class MyFloatInputElement : FloatInputElement { }




	public partial class TerrainRemixerConfig : StackableModConfig {
		public static TerrainRemixerConfig Instance => ModConfigStack.GetMergedConfigs<TerrainRemixerConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public List<TerrainRemixerGenPassSpec> Passes { get; set; } = new List<TerrainRemixerGenPassSpec>();



		////////////////

		public void Initialize() {
			this.Passes.Add( new TerrainRemixerGenPassSpec {
				GensAfterLayer = true,
				LayerName = "Terrain",
				//Filter = new TilePatternConfig( new TilePatternBuilder { IsActive = true } ),
				NoiseScale = 0.01f,
				BoundsTopStart = WorldDepth.Sky,
				BoundsBottomStart = WorldDepth.UgDirt,
				NoiseValueMinimumForSolidTile = 0.35f,
				HorizontalDistancePercentFromCenterBeforeBlending = 1f,
				VerticalDistancePercentFromCenterBeforeBlending = 0.5f,
			} );

			object _;
			if( !ReflectionHelpers.RunMethod( typeof(ConfigManager), null, "Save", new object[] { this }, out _ ) ) {
				LogHelpers.Alert( "Could not save config defaults." );
			}
		}
	}
}
