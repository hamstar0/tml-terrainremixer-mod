using System;
using System.Collections.Generic;
using Terraria.ModLoader.Config;
using HamstarHelpers.Services.Configs;
using HamstarHelpers.Classes.UI.ModConfig;
using HamstarHelpers.Classes.Tiles.TilePattern;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.DotNET.Reflection;


namespace TerrainRemixer {
	class MyFloatInputElement : FloatInputElement { }




	public partial class TerrainRemixerConfig : StackableModConfig {
		public static TerrainRemixerConfig Instance => ModConfigStack.GetMergedConfigs<TerrainRemixerConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public List<TerrainRemixerPassDefinition> Passes { get; set; } = new List<TerrainRemixerPassDefinition>();



		////////////////

		public void Initialize() {
			this.Passes.Add( new TerrainRemixerPassDefinition {
				IsAfter = true,
				LayerName = "Terrain",
				ReplacesLayer = false,
				Filter = new TilePatternConfig( new TilePatternBuilder { IsActive = true } ),
				Scale = 0.1f,
				MaxDepthOffset = 0,
				IsMaxDepthSurfaceBottom = true,
				IsMaxDepthDirtLayerBottom = false,
				IsMaxDepthRockLayerBottom = false,
				BaseNoisePercentThresholdMinimumForSolid = 0.35f,
				BaseNoisePercentThresholdMinimumForWall = 0.35f,
				FadesToBottom = true,
			} );

			object _;
			if( !ReflectionHelpers.RunMethod( typeof(ConfigManager), null, "Save", new object[] { this }, out _ ) ) {
				LogHelpers.Alert( "Could not save config defaults." );
			}
		}
	}
}
