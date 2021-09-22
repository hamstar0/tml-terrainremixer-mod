using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using ModLibsCore.Classes.UI.ModConfig;
using ModLibsCore.Libraries.Debug;


namespace TerrainRemixer {
	class MyFloatInputElement : FloatInputElement { }




	[Label( "Config" )]
	public partial class TerrainRemixerConfig : ModConfig {
		public static TerrainRemixerConfig Instance => ModContent.GetInstance<TerrainRemixerConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public bool DebugModeInfo { get; set; } = false;

		////

		public List<TerrainRemixerGenPassSpec> Passes { get; set; } = new List<TerrainRemixerGenPassSpec> {
			new TerrainRemixerGenPassSpec {
				LayerName = "Tunnels",
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
				LayerName = "Tunnels",
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
