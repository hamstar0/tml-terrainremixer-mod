using System;
using System.Collections.Generic;
using Terraria.ModLoader.Config;
using HamstarHelpers.Services.Configs;
using HamstarHelpers.Classes.UI.ModConfig;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.DotNET.Reflection;


namespace TerrainRemixer {
	class MyFloatInputElement : FloatInputElement { }




	[Label( "Config" )]
	public partial class TerrainRemixerConfig : StackableModConfig {
		public static TerrainRemixerConfig Instance => ModConfigStack.GetMergedConfigs<TerrainRemixerConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public List<TerrainRemixerGenPassSpec> Passes { get; set; } = new List<TerrainRemixerGenPassSpec>();



		////////////////

		public void Initialize() {
			this.Passes.Clear();
			
			this.Passes.Add( new TerrainRemixerGenPassSpec {
				GensAfterLayer = true,
				LayerName = "Terrain",
				//Filter = new TilePatternConfig( new TilePatternBuilder { IsActive = true } ),
				NoiseScale = 0.01f,
				NoiseValueMinimumUntilTileRemoval = 0.6f,
				BoundsTopStart = WorldDepth.SurfaceTop,
				BoundsBottomStart = WorldDepth.UnderworldTop,
				HorizontalDistancePercentFromCenterBeforeBlending = 0.8f,
				VerticalDistancePercentFromCenterBeforeBlending = 0.7f,
				BoundsLeftPercentStart = 0.48f,
				BoundsRightPercentStart = 0.52f,
			} );
			this.Passes.Add( new TerrainRemixerGenPassSpec {
				GensAfterLayer = true,
				LayerName = "Terrain",
				NoiseScale = 0.01f,
				NoiseValueMinimumUntilTileRemoval = 0.65f,
				BoundsTopStart = WorldDepth.UndergroundRockTop,
				BoundsBottomStart = WorldDepth.UnderworldTop,
				HorizontalDistancePercentFromCenterBeforeBlending = 0.75f,
				VerticalDistancePercentFromCenterBeforeBlending = 0.9f,
				BoundsLeftPercentStart = 0.2f,
				BoundsRightPercentStart = 0.8f,
				BoundsTopTileOffset = 200,
				BoundsBottomTileOffset = -200,
			} );

			object _;
			if( !ReflectionHelpers.RunMethod( typeof(ConfigManager), null, "Save", new object[] { this }, out _ ) ) {
				LogHelpers.Alert( "Could not save config defaults." );
			}
		}
	}
}
