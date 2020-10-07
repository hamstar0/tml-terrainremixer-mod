using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.UI.ModConfig;
using HamstarHelpers.Helpers.Debug;


namespace TerrainRemixer {
	class MyFloatInputElement : FloatInputElement { }




	[Label( "Config" )]
	public partial class TerrainRemixerConfig : ModConfig {
		public static TerrainRemixerConfig Instance => ModContent.GetInstance<TerrainRemixerConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public List<TerrainRemixerGenPassSpec> Passes { get; set; } = new List<TerrainRemixerGenPassSpec> {
			new TerrainRemixerGenPassSpec {
				GensAfterLayer = true,
				LayerName = "Terrain",
				//Filter = new TilePatternConfig( new TilePatternBuilder { IsActive = true } ),
				NoiseFrequency = 0.01f,
				NoiseValueMinimumUntilTileRemoval = 0.6f,
				BoundsTopStart = WorldDepth.SurfaceTop,
				BoundsBottomStart = WorldDepth.UnderworldTop,
				HorizontalDistancePercentFromCenterBeforeBlending = 0.8f,
				VerticalDistancePercentFromCenterBeforeBlending = 0.7f,
				BoundsLeftPercentStart = 0.48f,
				BoundsRightPercentStart = 0.52f,
				FillTiles = new List<int> { -1 },
				FillWalls = new List<int> { }
			},
			new TerrainRemixerGenPassSpec {
				GensAfterLayer = true,
				LayerName = "Terrain",
				NoiseFrequency = 0.01f,
				NoiseValueMinimumUntilTileRemoval = 0.65f,
				BoundsTopStart = WorldDepth.UndergroundRockTop,
				BoundsBottomStart = WorldDepth.UnderworldTop,
				HorizontalDistancePercentFromCenterBeforeBlending = 0.75f,
				VerticalDistancePercentFromCenterBeforeBlending = 0.9f,
				BoundsLeftPercentStart = 0.2f,
				BoundsRightPercentStart = 0.8f,
				BoundsTopTileOffset = 200,
				BoundsBottomTileOffset = -200,
				FillTiles = new List<int> { -1 },
				FillWalls = new List<int> { }
			}
		};
	}
}
